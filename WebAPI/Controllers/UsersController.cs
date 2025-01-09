using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _usersService;

        public UsersController(IUserService usersService)
        {
            _usersService = usersService;
        }

        [HttpGet("getAll")]
        public IActionResult Get()
        {

            var result=_usersService.GetAll();
            if (result.Success) 
            {
                return Ok(result);
            }
            return BadRequest(result);

          
        }
        [HttpGet("getAllInfo")]
        public IActionResult GetAllInfo(int id) 
        {

            var result = _usersService.GetUserAllInfo(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpPost]
        public IActionResult Post(User users)
        {
            var result=_usersService.Add(users);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getById")]
        public IActionResult Get(int id)
        {
            var result =_usersService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getbyproject")] 
        public IActionResult GetByProject(int getbyproject) 
        {
            var result=_usersService.GetByProject(getbyproject);
            if (result.Success)
            {
                return Ok(result);

            }
            return BadRequest(result);
        
        }

    }
}
