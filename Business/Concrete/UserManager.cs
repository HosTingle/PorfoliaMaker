using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspect.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public UserManager(IUserDal usersDal)
        {
            _usersDal = usersDal;
        }
        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {

            _usersDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<User>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<User>>(Messages.MainIntanceTime);
            }
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(),Messages.UsersList);
        }

        public IDataResult<List<User>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<User>>(_usersDal.GetAll(p=>p.UserId == id));
        }


        public IDataResult<User> GetById(int id)
        {
            return new SuccessDataResult<User>(_usersDal.Get(x=>x.UserId == id)); 
        }

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
    }
}
