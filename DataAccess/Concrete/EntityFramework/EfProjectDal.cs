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
        public List<ProjectWithPhotoDto> GetAllByIdProjectWithPhoto(int userId)
        {
            using (PortfContext context = new PortfContext())
            {
                var result = from u in context.Projects
                             join p in context.ProjectPhotos
                             on u.ProjectId equals p.ProjectId
                             where u.UserId == userId 
                             select new ProjectWithPhotoDto
                             {
                                 ProjectId = u.ProjectId,
                                 UserId = u.UserId,
                                 CreatedAt = u.CreatedAt,
                                 Title = u.Title,
                                 Description = u.Description,
                                 ProjectPhotoUrl = p.ProjectPhotoUrl,
                                 ProjectUrl = u.ProjectUrl
                             };

                return result.ToList();
            }
        }
        public List<ProjectDto> GetAllByIdProjectWithPhotos(int userId)
        {
            using (PortfContext context = new PortfContext())
            {
                return context.Projects
                    .Where(p => p.UserId == userId) 
                    .Select(p => new ProjectDto
                    {
                        Title = p.Title,
                        CreatedAt = p.CreatedAt,
                        Description = p.Description,
                        ProjectUrl = p.ProjectUrl,
                        PhotosUrls = context.ProjectPhotos
                            .Where(pp => pp.ProjectId == p.ProjectId)
                            .Select(pp => new ProjectPhotoDto
                            {
                                ProjectPhotoUrl = pp.ProjectPhotoUrl,
                                ProjectId = pp.ProjectId,
                                ProjectPhotoId = pp.ProjectPhotoId
                            })
                            .ToList()
                    })
                    .ToList();
            }
        }
        public ProjectWithPastPhotoDto GetProjetIdByUserId(ProjectWithPastPhotoDto projectWithPastPhotoDto) 
        {
            using (PortfContext context = new PortfContext())
            {
                var result = from u in context.Projects
                             where u.UserId == projectWithPastPhotoDto.UserId
                             where u.Title==projectWithPastPhotoDto.PastProjectTitle
                             select new ProjectWithPastPhotoDto
                             {
                                 ProjectId = u.ProjectId,
                                 UserId = u.UserId,
                                 CreatedAt = u.CreatedAt,
                                 Title = u.Title,
                                 Description = u.Description,
                                 ProjectPhotoUrl = projectWithPastPhotoDto.ProjectPhotoUrl,
                                 ProjectUrl = u.ProjectUrl,
                                 PastProjectTitle=u.Title,
                             };

                return result.SingleOrDefault()!;
            }
        }

    }

}
