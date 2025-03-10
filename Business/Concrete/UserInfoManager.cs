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

        public IResult Add(UserInfo userInfo) 
        {
            _userInfoDal.Add(userInfo);
            return new SuccessResult();
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

        public IResult UpdateUserInfoApplication(UserInfoApplicantDto userInfoApplicantDto)
        {
            userInfoApplicantDto.UserInfoId=_userDal.GetUserInfoIdByUserId(userInfoApplicantDto.UserId);
            var result=_userInfoDal.UpdateUserInfoApplication(userInfoApplicantDto);
            if (result)
            {
                return new SuccessResult(Messages.UserInfoApplicantSuccess);
            }
            return new ErrorResult(Messages.UserInfoApplicantError);
        } 

        public IResult UpdateUserInfoPersonal(UserInfoPersonalDto userInfoPersonalDto)
        {
            userInfoPersonalDto.UserInfoId = _userDal.GetUserInfoIdByUserId(userInfoPersonalDto.UserId);
            _userInfoDal.UpdateUserInfoPersonal(userInfoPersonalDto);
            return new SuccessResult(Messages.UserInfoPersonalSucces);
        }

        public IDataResult<UserInfoAboutDto> UpdateUserInfoAbout(UserInfoAboutDto userInfoAboutDto)
        {
            userInfoAboutDto.UserInfoId = _userDal.GetUserInfoIdByUserId(userInfoAboutDto.UserId);
            var result=_skillDal.UpdateSkills(userInfoAboutDto);
            if (result)
            {
                _userInfoDal.UpdateUserInfoAbout(userInfoAboutDto);
                userInfoAboutDto.Skills= _skillDal.GetAll(s=>s.UserId==userInfoAboutDto.UserId);
                return new SuccessDataResult<UserInfoAboutDto>( userInfoAboutDto,Messages.UserInfoAboutSucces);
            }
            return new ErrorDataResult<UserInfoAboutDto>(Messages.UserInfoAboutError);  
        }
    }
}
