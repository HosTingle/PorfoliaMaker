using Business.Abstract;
using Business.Constants;
using Castle.Components.DictionaryAdapter.Xml;
using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoController : BaseController
    {
        IUserInfoService _userInfoService;

        public UserInfoController(IUserInfoService userInfoService)
        {
            _userInfoService = userInfoService;
        }
        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _userInfoService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(UserInfo userInfo )
        {

            var result = _userInfoService.Add(userInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(UserInfo userInfo)
        {

            var result = _userInfoService.Delete(userInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(UserInfo userInfo)
        {

            var result = _userInfoService.Update(userInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _userInfoService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getByUserId")]
        public IActionResult getByUserId() 
        {
         
            int userId = GetUserIdFromToken();
            var result = _userInfoService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("UpdateUserInfoApplicant")]
        public IActionResult UpdateUserInfoApplicant(UserInfoApplicantDto userInfoApplicantDto)
        {
         var token = Request.Cookies["AuthToken"];
            int userId = GetUserIdFromToken();
            var result = _userInfoService.UpdateUserInfoApplicant(userId, userInfoApplicantDto);

            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPost("UpdateUserInfoPersonal")]
        public IActionResult UpdateUserInfoPersonal(UserInfoPersonalDto userInfoPersonalDto)
        {
            int userId = GetUserIdFromToken();
            var result = _userInfoService.UpdateUserInfoPersonal(userId,userInfoPersonalDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpPost("UpdateUserInfoAbout")]
        public IActionResult UpdateUserInfoAbout(UserInfoAboutDto userInfoAboutDto)
        {
            int userId = GetUserIdFromToken();
            var result = _userInfoService.UpdateUserInfoAbout(userId,userInfoAboutDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
        [HttpGet("SearchByNickname")]
        public IActionResult SearchByNickname(string nickName)  
        {
            var result = _userInfoService.SearchByNickname(nickName);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);

        }
    }
}
