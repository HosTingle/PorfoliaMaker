using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUsersService
    {
        List<Users> GetAll();

        List<Users> GetAllByCategory(int id);

        List<Users> GetByUserBetween(decimal min,decimal max);

        List<UsersDetailDto> GetUsersDetails();
    }
}
