using Business.Abstract;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ForeignLanguageController : BaseController
    {
        IForeignLanguageService _foreignLanguageService;

        public ForeignLanguageController(IForeignLanguageService foreignLanguageService)
        {
            _foreignLanguageService = foreignLanguageService;
        }

        [HttpPost("updateforeignlanguage")]
        public IActionResult UpdateCertificate(ForeignLanguageDto foreignLanguageDto)
        {
            int userId = GetUserIdFromToken();
            foreignLanguageDto.UserId = userId;
            var result = _foreignLanguageService.UpdateForeignLanguage(foreignLanguageDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
