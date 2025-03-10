using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkExperienceController : BaseController
    {
        IWorkExperienceService _workExperienceService;

        public WorkExperienceController(IWorkExperienceService workExperienceService)
        {
            _workExperienceService = workExperienceService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _workExperienceService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(WorkExperience workExperience)
        {

            var result = _workExperienceService.Add(workExperience);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(WorkExperience workExperience)
        {

            var result = _workExperienceService.Delete(workExperience);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(WorkExperience workExperience)
        {

            var result = _workExperienceService.Update(workExperience);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("updateworkexperience")]
        public IActionResult UpdateWorkExperience(WorkExperienceDto workExperienceDto) 
        {
            int userId = GetUserIdFromToken();
            workExperienceDto.UserId = userId;
            var result = _workExperienceService.UpdateWorkExperience(workExperienceDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _workExperienceService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
    }
}
