using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUsersDal _usersDal;

        public UserManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public IResult Add(Users user)
        {

            if (user.FullName.Length < 2)
            {
                return new ErrorResult(Messages.UserNameInvalid);
            }
            _usersDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IDataResult<List<Users>> GetAll()
        {
            if (DateTime.Now.Hour == 11)
            {
                return new ErrorDataResult<List<Users>>(Messages.MainIntanceTime);
            }
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(),Messages.UsersList);
        }

        public IDataResult<List<Users>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(p=>p.UserId == id));
        }


        public IDataResult<Users> GetById(int id)
        {
            return new SuccessDataResult<Users>(_usersDal.Get(x=>x.UserId == id)); 
        }

        public IDataResult<List<Users>> GetByUserBetween(decimal min, decimal max) 
        {
            return new SuccessDataResult<List<Users>>(_usersDal.GetAll(p => p.UserId>min &&  p.UserId < max));
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
