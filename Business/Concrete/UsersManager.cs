using Business.Abstract;
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
    public class UsersManager : IUsersService
    {
        IUsersDal _usersDal;

        public UsersManager(IUsersDal usersDal)
        {
            _usersDal = usersDal;
        }

        public List<Users> GetAll()
        {
            return _usersDal.GetAll();
        }

        public List<Users> GetAllByCategory(int id)
        {
            return _usersDal.GetAll(p=>p.UserId == id);
        }

        public List<Users> GetBuUnitePrice(decimal min, decimal max)
        {
            throw new NotImplementedException();
        }

        public List<Users> GetByUserBetween(decimal min, decimal max) 
        {
            return _usersDal.GetAll(p => p.UserId>min &&  p.UserId < max);
        }

        public List<UsersDetailDto> GetUsersDetails()
        {
            return _usersDal.GetUsersDetails();
        }
    }
}
