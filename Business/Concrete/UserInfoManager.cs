using Business.Abstract;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserInfoManager : IUserInfoService
    {
        IUserInfoDal _userInfoDal;
        IUserDal _userDal;
        ISkillDal _skillDal;
        public UserInfoManager(IUserInfoDal userInfoDal,IUserDal userDal,ISkillDal skillDal)
        {
            _userInfoDal = userInfoDal;
            _userDal = userDal;
            _skillDal = skillDal;
        }

        public IDataResult<UserInfo> Add(UserInfo userInfo) 
        {
            var result=_userInfoDal.AddGetInfo(userInfo);
            return new SuccessDataResult<UserInfo>(result);
        }

        public IResult Delete(UserInfo userInfo)
        {
            _userInfoDal.Delete(userInfo);
            return new SuccessResult();
        }

        public IDataResult<UserInfo> GetById(int id) 
        {
            return new SuccessDataResult<UserInfo>(_userInfoDal.Get(s => s.UserInfoId == id));
        }
        public IDataResult<UserInfo> GetByUserId(int id)
        {
            var UserInfoId = _userDal.GetUserInfoIdByUserId(id);
            return new SuccessDataResult<UserInfo>(_userInfoDal.Get(s => s.UserInfoId == UserInfoId));
        }
        public IDataResult<List<UserInfo>> GetAll()
        {
            return new SuccessDataResult<List<UserInfo>>(_userInfoDal.GetAll());
        }

        public IResult Update(UserInfo userInfo)
        {
            _userInfoDal.Update(userInfo);
            return new SuccessResult();
        }
        public IDataResult<List<UserSearchResultDto>> SearchByNickname(string nickname)
        {
            return new SuccessDataResult<List<UserSearchResultDto>>(_userInfoDal.SearchByNickname(nickname), Messages.UserInfoAboutSucces);
        }

        public IDataResult<int?> GetUserIdByDetails(int userInfoId)
        {
            return new SuccessDataResult<int?>(_userInfoDal.GetUserIdByDetails(userInfoId));
        }
        public IResult UpdateUserInfoPersonal(int userId, UserInfoPersonalDto userInfoPersonalDto)
        {
            var id = _userInfoDal.GetUserIdByDetails(userInfoPersonalDto.UserInfoId);
            if (id != userId)
            {
                return new ErrorResult(Messages.UnAuthorizedAccess);
            }
            userInfoPersonalDto.UserId= userId;
            _userInfoDal.UpdateUserInfoPersonal(userInfoPersonalDto);
            return new SuccessResult(Messages.UserInfoPersonalSucces);
        }
        public IDataResult<UserInfoAboutDto> UpdateUserInfoAbout(int userId, UserInfoAboutDto userInfoAboutDto)
        {
    
            if (_userInfoDal.GetUserIdByDetails(userInfoAboutDto.UserInfoId) != userId)
            {
                return new ErrorDataResult<UserInfoAboutDto>(Messages.UnAuthorizedAccess);
            }

            userInfoAboutDto.UserId = userId;

       
            if (!_skillDal.UpdateSkills(userInfoAboutDto))
            {
                return new ErrorDataResult<UserInfoAboutDto>(Messages.UserInfoAboutError);
            }


            if (!_userInfoDal.UpdateUserInfoAbout(userInfoAboutDto))
            {
                return new ErrorDataResult<UserInfoAboutDto>(Messages.UserInfoAboutError);
            }

     
            userInfoAboutDto.Skills = _skillDal.GetAll(s => s.UserId == userInfoAboutDto.UserId);

  
            if (!_userDal.UpdateUser(userId, userInfoAboutDto.PhotoUrl!))
            {
                return new ErrorDataResult<UserInfoAboutDto>(Messages.UserInfoAboutError);
            }

            return new SuccessDataResult<UserInfoAboutDto>(userInfoAboutDto, Messages.UserInfoAboutSucces);
        }

        public IResult UpdateUserInfoApplicant(int userId, UserInfoApplicantDto userInfoApplicantDto)
        {
            var id = _userInfoDal.GetUserIdByDetails(userInfoApplicantDto.UserInfoId);
            if (id != userId)
            {
                return new ErrorResult(Messages.UnAuthorizedAccess);
            }

            userInfoApplicantDto.UserId = userId;

            var updateResult = _userInfoDal.UpdateUserInfoApplication(userInfoApplicantDto);
            if (updateResult)
            {
                return new SuccessResult(Messages.UserInfoApplicantSuccess);
            }

            return new ErrorResult(Messages.UserInfoApplicantError);
        }
    }
}
