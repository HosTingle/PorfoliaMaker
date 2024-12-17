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
        IDataResult<List<User>> GetAll();

        IDataResult<List<User>> GetAllByCategory(int id);

        IDataResult<List<User>> GetByUserBetween(decimal min,decimal max);

        IDataResult<List<UsersDetailDto> >GetUsersDetails();

        IResult Add(User user);

        IDataResult<User> GetById(int id);
    }
}
