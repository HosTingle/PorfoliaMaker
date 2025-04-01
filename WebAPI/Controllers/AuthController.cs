﻿using Business.Abstract;
using Core.Utilities.Results;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
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
                return Ok(result);
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
        public ActionResult IsAuthenticated()
        {
            var token = Request.Cookies["AuthToken"];
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized(new ErrorResult("Yetkisiz erişim!"));
            }
            return Ok(new SuccessResult("Giriş Başarılı"));
        }

    }
}
