
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Core.Utilities.UploadPhoto.UploadService;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.UploadPhoto.PhotoUpload
{
    public class PhotoManager : IPhotoService
    {
        private readonly HttpClient _httpClient;
        public IConfiguration Configuration { get; }
        private ImageBB _ImageBB; 
        public PhotoManager(HttpClient httpClient, IConfiguration configuration)
        {
            Configuration = configuration;
            _ImageBB = Configuration.GetSection("ImageBB") 
                 .Get<ImageBB>();
            _httpClient = httpClient;
        }

        public IDataResult<ImageUploadResponse> UploadImage(IFormFile image)
        {
            try
            {
                using (var ms = new MemoryStream())
                {
                    image.CopyTo(ms);
                    var byteArray = ms.ToArray();
                    var content = new MultipartFormDataContent();
                    var imageContent = new ByteArrayContent(byteArray);
                    imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse("image/jpeg");

                    content.Add(imageContent, "image", image.FileName);

                    string imgbbApiKey = _ImageBB.ImageBBKey;
                    string imgbbUrl = $"https://api.imgbb.com/1/upload?key={imgbbApiKey}";

                    var response = _httpClient.PostAsync(imgbbUrl, content).Result;  // Senkron hale getirildi

                    if (!response.IsSuccessStatusCode)
                    {
                        return new ErrorDataResult<ImageUploadResponse>( "ImgBB yükleme hatası.");
                    }

                    var result = response.Content.ReadAsStringAsync().Result; // Senkron hale getirildi
                    var jsonResponse = JsonConvert.DeserializeObject<dynamic>(result);
                    var data = jsonResponse.data;

                    var imageResponse = new ImageUploadResponse
                    {
                        Id = data.id?.ToString(),
                        Title = data.title?.ToString(),
                        Url = data.url?.ToString(),
                        DisplayUrl = data.display_url?.ToString(),
                        ThumbUrl = data.thumb != null ? data.thumb.url?.ToString() : null,
                        MediumUrl = data.medium != null ? data.medium.url?.ToString() : null,
                        DeleteUrl = data.delete_url?.ToString()
                    };


                    return new SuccessDataResult<ImageUploadResponse>(imageResponse, "Resim başarıyla yüklendi" );
                }
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ImageUploadResponse>( $"Hata oluştu: {ex.Message}");
            }
        }


    }
}
