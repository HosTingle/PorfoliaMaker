using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<Users>> GetAll();

        IDataResult<List<Users>> GetAllByCategory(int id);

        IDataResult<List<Users>> GetByUserBetween(decimal min,decimal max);

        IDataResult<List<UsersDetailDto> >GetUsersDetails();

        IResult Add(Users user);

        IDataResult<Users> GetById(int id);
    }
}
