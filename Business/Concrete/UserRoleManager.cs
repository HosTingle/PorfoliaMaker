using Business.Abstract;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserRoleManager : IUserRoleService
    {
        IUserRoleDal _userRoleDal;

        public UserRoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public IResult Add(UserRole userRole)
        {
            _userRoleDal.Add(userRole);
            return new SuccessResult();
        }

        public IResult Delete(UserRole userRole)
        {
            _userRoleDal.Delete(userRole);
            return new SuccessResult();
        }

        public IDataResult<List<UserRole>> GetAll()
        {
            return new SuccessDataResult<List<UserRole>>(_userRoleDal.GetAll());
        }

        public IDataResult<UserRole> GetById(int id)
        {
            return new SuccessDataResult<UserRole>(_userRoleDal.Get(s => s.UserId == id));
        }

        public IResult Update(UserRole userRole)
        {
            _userRoleDal.Update(userRole);
            return new SuccessResult();
        }
    }
}
