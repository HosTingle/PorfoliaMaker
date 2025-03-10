using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationInfoController :  BaseController
    {
        IEducationService _educationService;

        public EducationInfoController(IEducationService educationService)
        {
            _educationService = educationService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _educationService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(EducationInfo educationInfo)
        {

            var result = _educationService.Add(educationInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(EducationInfo educationInfo)
        {

            var result = _educationService.Delete(educationInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(EducationInfo educationInfo)
        {

            var result = _educationService.Update(educationInfo);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _educationService.GetById(id);
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
            var result = _educationService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("updateeducation")]
        public IActionResult educationUpdate(EducationInfoDto educationInfoDto) 
        {
            educationInfoDto.UserId = GetUserIdFromToken();
            var result = _educationService.UpdateEducation(educationInfoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
