using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialLinksController : BaseController
    {
        ISocialLinkService _socialLinkService;

        public SocialLinksController(ISocialLinkService socialLinkService)
        {
            _socialLinkService = socialLinkService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _socialLinkService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(SocialLink socialLink)
        {

            var result = _socialLinkService.Add(socialLink);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(SocialLink socialLink)
        {

            var result = _socialLinkService.Delete(socialLink);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(SocialLink socialLink)
        {

            var result = _socialLinkService.Update(socialLink);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("updatesociallink")]
        public IActionResult UpdateSocialLink(socialLinkDto socialLinkDto) 
        {
            int userId = GetUserIdFromToken();
            socialLinkDto.UserId = userId;
            var result = _socialLinkService.UpdateSocialLink(socialLinkDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _socialLinkService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
