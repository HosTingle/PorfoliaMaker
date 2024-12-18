using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.IO.MemoryMappedFiles;
using Core.DataAccess.EntityFramework;
using Entities.DTOs;
using Core.Entities.Concrete;
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, PortfContext>, IUserDal
    {
        public List<Role> GetClaims(User user)
        {
            using (var context = new PortfContext())
            {
                var result = from role in context.Roles
                             join userrole in context.UserRoles
                                 on role.RoleId equals userrole.RoleId
                             where userrole.UserId == user.UserId
                             select new Role { RoleId = role.RoleId, RoleName= role.RoleName };
                return result.ToList();

            }
        }
        public List<UsersDetailDto> GetUsersDetails()
        {
            using (PortfContext context = new PortfContext())
            {
                var result = from u in context.Users
                             join p in context.Projects
                             on u.UserId equals p.UserId
                             select new UsersDetailDto
                             {
                                 UserId = p.UserId,
                                 Bio = u.Bio,
                                 CreatedAt = u.CreatedAt,
                                 Email = u.Email,
                                 FullName = u.FullName,
                                 PasswordHash = u.PasswordHash,
                                 PasswordSalt = u.PasswordSalt,
                                 ProfilePhoto = u.ProfilePhoto,
                                 Title = p.Title,
                                 Status=u.Status,
                                 
                             };
                return result.ToList();


            }

        }
    }
}
