using Core.Entities.Concrete;
using Core.Utilities.Results;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.UploadPhoto.PhotoUpload
{
    public interface IPhotoService
    {
        IDataResult<ImageUploadResponse> UploadImage(IFormFile image);


    }
}
