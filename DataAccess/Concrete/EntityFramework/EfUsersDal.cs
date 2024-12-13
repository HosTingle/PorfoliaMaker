using DataAccess.Abstract;
using Entities.Concrete;
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
namespace DataAccess.Concrete.EntityFramework
{
    public class EfUsersDal : EfEntityRepositoryBase<Users, PortfContext>, IUsersDal
    {
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
                                 Title = p.Title
                             };
                return result.ToList();


            }

        }
    }
}
