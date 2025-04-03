using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController :BaseController
    {
        private IAuthService _authService;
        private IUserService _userService;
        public AuthController(IAuthService authService,IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public ActionResult Login(UserForLoginDto userForLoginDto)
        {
            var userToLogin = _authService.Login(userForLoginDto);
            if (!userToLogin.Success)
            {
                return BadRequest(userToLogin);
            }

            var result = _authService.CreateAccessToken(userToLogin);
            if (result.Success)
            {
                var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,  
                    Secure = true,    
                    SameSite = SameSiteMode.None, 
                    Expires = result.Data.Expiration 
                };
                Response.Cookies.Append("AuthToken", result.Data.Token, cookieOptions);
                var result2= _userService.GetUserAllInfo(userToLogin.Data.UserId);
                return Ok(result2);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public ActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = _authService.UserExists(userForRegisterDto.Email);
            if (!userExists.Success)
            {
                return BadRequest(userExists.Message);
            }

            var registerResult = _authService.Register(userForRegisterDto, userForRegisterDto.Password);
            var result = _authService.CreateAccessToken(registerResult);
            if (result.Success)
            { 
                var addrole = _authService.AddUserRole(registerResult);
                if (addrole.Success)
                {
                    return Ok(result);
                }
            }

            return BadRequest(result);
        }

        [HttpGet("isAuthenticated")]
        public IActionResult IsAuthenticated()
        {
            var token = Request.Cookies["AuthToken"];
     
            if (string.IsNullOrEmpty(token))
            {
                var resulter = new ErrorResult("Yetkisiz erişim!");
                return Unauthorized(resulter);
            }
         
            var result = new SuccessResult("Giriş başarılı.");
            return Ok(result);
        }
        [HttpPost("logout")]
        public IActionResult Logout()
        {
            var cookieOptions = new CookieOptions
            {
                Expires = DateTime.UtcNow.AddDays(-1), 
                HttpOnly = true,
                Secure = true, 
                SameSite = SameSiteMode.Lax,
                Path = "/" 
            };

            Response.Cookies.Append("AuthToken", "", cookieOptions);
            var result = new SuccessResult("Çıkış İşemi Gerçekleşti");
            return Ok(result);
        }


    }
}
