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
                                 NickName=u.NickName,
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
        public UserAllInfoDto GetUsersAllInfo(int userId)
        {
            using (PortfContext context = new PortfContext())
            {
                var user = context.Users.Where(u => u.UserId == userId)
                                         .Select(u => new UserAllInfoDto
                                         {
                                             Name = u.FullName,
                                             NickName=u.NickName,
                                             ProfilePhoto=u.ProfilePhoto,
                                             Skills = context.Skills.Where(s => s.UserId == u.UserId).ToList(),
                                             Certificates = context.Certificates.Where(c => c.UserId == u.UserId).ToList(),
                                             Projects = context.Projects.Where(p => p.UserId == u.UserId).ToList(),
                                             Blogs = context.Blogs.Where(b => b.UserId == u.UserId).ToList(),
                                             Comments = context.Comments.Where(co => co.UserId == u.UserId).ToList(),
                              
                                             Github = context.SocialLinks.Where(sl => sl.UserId == u.UserId && sl.Platform.ToLower() == "github").Select(sl => sl.Url).FirstOrDefault() ?? "No GitHub",
                                             LinkedIn = context.SocialLinks.Where(sl => sl.UserId == u.UserId && sl.Platform.ToLower() == "linkedin").Select(sl => sl.Url).FirstOrDefault() ?? "No LinkedIn",
                                             Website = context.SocialLinks.Where(sl => sl.UserId == u.UserId && sl.Platform.ToLower() == "website").Select(sl => sl.Url).FirstOrDefault() ?? "No Website",


                                         })
                                         .AsEnumerable()
                                         .FirstOrDefault();

                if (user != null)
                {
                    return user;
                }
                else
                {

                    return null;
           
                }
            }
        }

        public UserById GetUserById(int id)
        {
            using (PortfContext context = new PortfContext())
            {
                var result = from u in context.Users
                             select new UserById
                             {
                                 UserId = u.UserId,
                                 Bio = u.Bio,
                                 CreatedAt = u.CreatedAt,
                                 NickName = u.NickName,
                                 Email = u.Email,
                                 FullName = u.FullName,

                                 ProfilePhoto = u.ProfilePhoto,
                                 Status = u.Status,

                             };
                return result.AsEnumerable().FirstOrDefault(); ;


            }
        }
    }
}
