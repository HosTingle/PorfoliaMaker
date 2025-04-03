using Business.Abstract;
using Business.Concrete;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
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
        public IActionResult GetAllInfo() 
        {
            int userId = GetUserIdFromToken();
            var result = _usersService.GetUserAllInfo(userId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getAllInfoByName")]
        public IActionResult GetAllInfoName(string name) 
        {
 
            var result = _usersService.GetUserAllInfoByUserName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);


        }
        [HttpGet("getAllInfoOther")]
        public IActionResult GetAllInfoOther(int id) 
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
        public IActionResult GetById() 
        {
            int userId = GetUserIdFromToken();
            var result =_usersService.GetById(userId);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet("getByIdName")]
        public IActionResult GetByIdName()
        {
            int userId = GetUserIdFromToken();
            var result = _usersService.GetUsernameById(userId);
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

        [HttpGet("isOwnProfile/{username}")]
        public IActionResult isOwnProfile(string username)
        {
            var resultuser = GetUserUsername();
            if (resultuser != username)
            {
                var resulter = new ErrorResult("Yetkisiz Erişim");
                return Ok(resulter);
            }

            var result = new SuccessResult("Erişme başarılı");

            return Ok(result);

        }

    }
}
