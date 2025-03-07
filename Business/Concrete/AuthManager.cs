﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        private IUserService _userService;
        private ITokenHelper _tokenHelper;
        private IUserRoleService _userRoleService;  

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, IUserRoleService userRoleService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userRoleService = userRoleService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                NickName=userForRegisterDto.NickName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                CreatedAt = DateTime.UtcNow,
                ProfilePhoto= "https://i.pinimg.com/736x/09/21/fc/0921fc87aa989330b8d403014bf4f340.jpg",
                Status = true,
                UserInfoId=1
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user, Messages.UserRegistered);
        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var userToCheck = _userService.GetByMail(userForLoginDto.Email);
            if (userToCheck == null)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(userForLoginDto.Password, userToCheck.PasswordHash, userToCheck.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }

            return new SuccessDataResult<User>(userToCheck, Messages.SuccessfulLogin);
        }

        public IResult UserExists(string email)
        {
            if (_userService.GetByMail(email) != null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }
            return new SuccessResult();
        }

        public IDataResult<AccessToken> CreateAccessToken(IDataResult<User> user)
        {
            var claims = _userService.GetClaims(user.Data);
            var accessToken = _tokenHelper.CreateToken(user.Data, claims);
            return new SuccessDataResult<AccessToken>(accessToken, user.Message);
        }
        public IResult AddUserRole(IDataResult<User> user) 
        {
            var userRole = new UserRole {
                UserId=user.Data.UserId,
                RoleId=3
            };
            var result=_userRoleService.Add(userRole);
            if (!result.Success)
            {
                new ErrorResult(Messages.UserRoleErrorMesage);

            }
            return new SuccessResult();
        }
    }
}
