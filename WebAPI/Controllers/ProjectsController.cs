using Business.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : BaseController
    {
        IProjectService _projectService;

        public ProjectsController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            var result = _projectService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getAllByUserId")] 
        public IActionResult GetAllByUserId() 
        {
            int userId = GetUserIdFromToken();
            var result = _projectService.GetByUserId(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getAllProjectDetailById")]
        public IActionResult GetProjectDetailByUserId()
        {
            int userId = GetUserIdFromToken();
            var result = _projectService.GetAllProjectWithPhotos(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("add")]
        public IActionResult Add(Project project)
        {
            int userId = GetUserIdFromToken();

            project.UserId = userId;
            var result = _projectService.Add(project);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("delete")]
        public IActionResult Delete(Project project)
        {

            var result = _projectService.Delete(project);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("update")]
        public IActionResult Update(Project project)
        {

            var result = _projectService.Update(project);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("UpdateProjectWithPhoto")]
        public IActionResult UpdateProjectWithPhoto(ProjectWithPastPhotoDto projectWithPastPhotoDto)  
        {
            int userId = GetUserIdFromToken();
            projectWithPastPhotoDto.UserId = userId;
            var result = _projectService.UpdatePhotoWithProject(projectWithPastPhotoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getById")]
        public IActionResult getById(int id)
        {

            var result = _projectService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost("AddProjectWithPhoto")]
        public IActionResult AddProjectWithPhoto(ProjectWithPhotoDto projectWithPhotoDto)
        {
            int userId = GetUserIdFromToken();
            projectWithPhotoDto.UserId = userId;    
            var result=_projectService.AddPhotoWithProject(projectWithPhotoDto);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
