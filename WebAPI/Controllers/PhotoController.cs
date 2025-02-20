using Business.Abstract;
using Core.Utilities.UploadPhoto.PhotoUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhotoController : BaseController
    {
        IPhotoService _photoService;

        public PhotoController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        [HttpPost("upload")]
        public IActionResult UploadImage( IFormFile image)
        {
            var result = _photoService.UploadImage(image);
            return Ok(result);
        }
    }
}
