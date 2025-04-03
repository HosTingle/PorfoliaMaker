using Core.DataAccess;
using Core.Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<UsersDetailDto> GetUsersDetails();

        List<Role> GetClaims(User user);

        UserAllInfoDto GetUsersAllInfo(int id);

        UserById GetUserById(int id);

        int GetUserInfoIdByUserId(int id);

        User AddGetId(User user);

        bool UpdateUser(int id, string newProfilePhotoUrl);

        string GetUsernameById(int id);

    }
}
