using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.Concrete;
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
        private IUserInfoService _userInfoService;
        private ISocialLinkService _socialLinkService;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper, 
            IUserRoleService userRoleService,IUserInfoService userInfoService,ISocialLinkService socialLinkService)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
            _userRoleService = userRoleService;
            _userInfoService = userInfoService;
            _socialLinkService=socialLinkService;
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
  

            var userInfo = new UserInfo();
            userInfo.FullName=userForRegisterDto.FullName;
            userInfo.NickName=userForRegisterDto.NickName;

            var result=_userInfoService.Add(userInfo);

            if (result.Success)
            {
                var user = new User
                {
                    Email = userForRegisterDto.Email,
             
                    PasswordHash = passwordHash,
                    PasswordSalt = passwordSalt,
                    CreatedAt = DateTime.UtcNow,
                    ProfilePhoto = "https://i.pinimg.com/736x/09/21/fc/0921fc87aa989330b8d403014bf4f340.jpg",
                    Status = true,
                    UserInfoId = result.Data.UserInfoId,
                };

                var number = _userService.Add(user).Data;
                IResult soci = AddSocial(number);
                if (soci.Success)
                {
                    return new SuccessDataResult<User>(user, Messages.UserRegistered);
                }

            }
            return new ErrorDataResult<User>( Messages.UserRegisteredError); 
        }

        private IResult AddSocial(int number)
        {
            var socialLinks = new List<SocialLink>{
    new SocialLink { SocialLinkId = 0, UserId =number, Platform = "Github", Url = null },
    new SocialLink { SocialLinkId = 0, UserId = number, Platform = "Website", Url = null },
    new SocialLink { SocialLinkId = 0, UserId = number, Platform = "LinkedIn", Url = null }
                };
            var socialLinkDto = new socialLinkDto()
            {
                socialLinks = socialLinks,
                UserId = number,
            };


            var soci = _socialLinkService.UpdateSocialLink(socialLinkDto);
            return soci;
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
