using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Caching;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidationException = FluentValidation.ValidationException;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
 
        IUserDal _usersDal;
        IUserInfoDal _userInfoDal; 
   
        public UserManager(IUserDal usersDal, IUserInfoDal userInfoDal)
        {
            _usersDal = usersDal;
            _userInfoDal = userInfoDal;
        }


        [ValidationAspect(typeof(UserValidator))]
        public IDataResult<int> Add(User user)
        {
            IResult result=BusinessRules.Run(EmailKontrol(user), KisiSinirla());

            if (result != null)
            {
                return new ErrorDataResult<int>(Messages.UserAdded);
            }
            var number=_usersDal.AddGetId(user).UserId; 
            return new SuccessDataResult<int>(number,Messages.UserAdded);
        }


        [CacheAspect]
        public IDataResult<List<User>> GetAll()
        {
       
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(),Messages.UsersList);
        }
        [SecuredOperation("product.add,admin")]
        public IDataResult<List<User>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(p=>p.UserId == id));
        }
        [SecuredOperation("user")]
        public IDataResult<UserById> GetById(int id)
        {
            return new SuccessDataResult<UserById>(_usersDal.GetUserById(id)); 
        }

        [CacheRemoveAspect("User_*")]
        public IDataResult<List<User>> GetByUserBetween(decimal min, decimal max) 
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(p => p.UserId>min &&  p.UserId < max));
        }

        public IDataResult<List<UsersDetailDto>> GetUsersDetails()
        {
            //if (DateTime.Now.Hour == 19)
            //{
            //    return new ErrorDataResult<List<UsersDetailDto>>(Messages.MainIntanceTime);
            //}
            return new SuccessDataResult<List<UsersDetailDto>>(_usersDal.GetUsersDetails());
        }
        private IResult KisiSinirla()
        {
            var result = _usersDal.GetAll();
            if (result.Count > 15)
            {
                return new ErrorResult(Messages.MessageFAS);
            }
            return new SuccessResult();
        }
        private IResult EmailKontrol(User user)
        {
            if (_usersDal.GetAll(u => u.Email == user.Email).Any())
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            return new SuccessResult();
        }

        public List<Role> GetClaims(User user)
        {
            return _usersDal.GetClaims(user);
        }
        public IDataResult<string> GetUsernameById(int id) 
        {
            var result = _usersDal.GetUsernameById(id);
            if (result != null)
            {
                return new SuccessDataResult<string>(result, Messages.UserInfoPersonalSucces);
            }
            return new ErrorDataResult<string>(result, Messages.UserInfoPersonalSucces);

        }

        public User GetByMail(string email)
        {
            var result= _usersDal.Get(u => u.Email == email);
            return result;
        }

        public IResult AddTransactionTest(User user)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<User>> GetByProject(int getbyproject)
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(x=>x.UserId == getbyproject));
       
        }
        public IDataResult<UserAllInfoDto>? GetUserAllInfo(int id) 
        {
            return new SuccessDataResult<UserAllInfoDto>(_usersDal.GetUsersAllInfo(id), Messages.LoginSucces);
        }
        public IDataResult<UserAllInfoDto>? GetUserAllInfoByUserName(string name) 
        {
            var result = _userInfoDal.SearchByNickname(name);
            return new SuccessDataResult<UserAllInfoDto>(_usersDal.GetUsersAllInfo(result[0].UserId));
        }
    }
}
