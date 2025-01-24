using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProjectDal:EfEntityRepositoryBase<Project,PortfContext>,IProjectDal
    {
        public ProjectWithPhoto ProjectWithPhoto()
        {
            using (PortfContext context = new PortfContext())
            {
                var result = from u in context.Projects
                             join p in context.ProjectPhotos
                             on u.ProjectPhotoId equals p.ProjectPhotoId
                             select new ProjectWithPhoto
                             {
                                ProjectId = u.ProjectId,
                                UserId = u.UserId,
                                CreatedAt = u.CreatedAt,
                                Description = u.Description,
                                ProjectPhotoId=p.ProjectPhotoUrl,
                                ProjectUrl = u.ProjectUrl
                               


                             };
                return result.FirstOrDefault();


            }
        }
    }
}
