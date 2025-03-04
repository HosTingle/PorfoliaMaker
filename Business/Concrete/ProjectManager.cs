using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectDal _projectsDal;
        IProjectPhotoService _projectPhotoService; 
        public ProjectManager(IProjectDal projectsDal,IProjectPhotoService projectPhotoService) 
        {
            _projectsDal = projectsDal;
            _projectPhotoService = projectPhotoService;
        }

        public IResult AddPhotoWithProject(ProjectWithPhotoDto projectWithPhotoDto) 
        {
            Project project = new Project
            {
                UserId = projectWithPhotoDto.UserId,
                ProjectId = projectWithPhotoDto.ProjectId,
                CreatedAt = projectWithPhotoDto.CreatedAt,
                Description = projectWithPhotoDto.Description,
                ProjectUrl = projectWithPhotoDto.ProjectUrl,
                Title = projectWithPhotoDto.Title,
            };
            IResult result = Add(project); 
            if (!result.Success)
            {
                return result;
            }
            projectWithPhotoDto.ProjectId= GetByTitle(project).ProjectId;

            if (AddProjectPhoto(projectWithPhotoDto).Success)
            {
                return new SuccessResult(Messages.BlogNotAdd);
            }
            return new ErrorResult(Messages.BlogNotAdd);

        }
        public IResult DeletePhototWithProject(ProjectWithPastPhotoDto projectWithPastPhotoDto) 
        {
            ProjectWithPastPhotoDto datawithProjectId = _projectsDal.GetProjetIdByUserId(projectWithPastPhotoDto);
            if (DeleteProjectPhoto(datawithProjectId).Success)
            {
                Project project = new Project
                {
                    UserId = projectWithPastPhotoDto.UserId,
                    ProjectId = datawithProjectId.ProjectId,
                    CreatedAt = projectWithPastPhotoDto.CreatedAt,
                    Description = projectWithPastPhotoDto.Description,
                    ProjectUrl = projectWithPastPhotoDto.ProjectUrl,
                    Title = projectWithPastPhotoDto.Title,
                };
                IResult result = Delete(project);
                if (result.Success)
                {
                    return new SuccessResult(Messages.ProjectDelete);
                }
         
     
            }
            return new ErrorResult(Messages.ProjectNotDelete); 



        }
        public IResult DeleteProjectPhoto(ProjectWithPastPhotoDto projectWithPastPhotoDto) 
        {
            List<ProjectPhoto> projectphotopast = _projectPhotoService.GetAllById(projectWithPastPhotoDto.ProjectId).Data;
            ProjectPhoto projectPhoto = new ProjectPhoto
            {
                ProjectId = projectWithPastPhotoDto.ProjectId,
                ProjectPhotoUrl = projectWithPastPhotoDto.ProjectPhotoUrl,
                ProjectPhotoId = projectphotopast[0].ProjectPhotoId,
            };
            var result = _projectPhotoService.Delete(projectPhoto);
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Profil Photo Eklenemedi");

        }
        public IResult Add(Project project)
        {
            _projectsDal.Add(project); 
            return new SuccessResult();
        }
        public IResult Delete(Project project)
        {
            _projectsDal.Delete(project);
            return new SuccessResult();
        }

        public IDataResult<List<Project>> GetAll()
        { 

            return new SuccessDataResult<List<Project>>( _projectsDal.GetAll());
        }
        public IDataResult<List<ProjectDto>> GetAllProjectWithPhotos(int id) 
        {

            return new SuccessDataResult<List<ProjectDto>>(_projectsDal.GetAllByIdProjectWithPhotos(id));
        }

        public IDataResult<Project> GetById(int id) 
        {
            return new SuccessDataResult<Project>(_projectsDal.Get(c=>c.ProjectId==id));
        }
        public IDataResult<List<Project>> GetByUserId(int id) 
        {
            return new SuccessDataResult<List<Project>>(_projectsDal.GetAll(c => c.UserId == id));
        }
        [SecuredOperation("user")]
        public IDataResult<List<ProjectWithPhotoDto>> GetProjectDetailByUserId(int userId)   
        {
            return new SuccessDataResult<List<ProjectWithPhotoDto>>(_projectsDal.GetAllByIdProjectWithPhoto(userId));
        }

        public IResult Update(Project project)
        {
            _projectsDal.Update(project);
            return new SuccessResult();
        }
        public IResult AddProjectPhoto(ProjectWithPhotoDto projectWithPhotoDto)
        {
            ProjectPhoto projectPhoto = new ProjectPhoto
            {
                ProjectId = projectWithPhotoDto.ProjectId,
                ProjectPhotoUrl = projectWithPhotoDto.ProjectPhotoUrl,
            };
            var result = _projectPhotoService.Add(projectPhoto);
            if (result.Success ){
                return new SuccessResult();
            }
            return new ErrorResult("Profil Photo Eklenemedi");

        }
        public IResult UpdatePhotoWithProject(ProjectWithPastPhotoDto projectWithPastPhotoDto)
        {
            ProjectWithPastPhotoDto datawithProjectId= _projectsDal.GetProjetIdByUserId(projectWithPastPhotoDto);
            Project project = new Project
            { 
                UserId = projectWithPastPhotoDto.UserId,
                ProjectId = datawithProjectId.ProjectId,
                CreatedAt = projectWithPastPhotoDto.CreatedAt,
                Description = projectWithPastPhotoDto.Description,
                ProjectUrl = projectWithPastPhotoDto.ProjectUrl,
                Title = projectWithPastPhotoDto.Title,
            };
            IResult result = Update(project);
            if (!result.Success)
            {
                return result;
            }
            projectWithPastPhotoDto.ProjectId = GetByTitle(project).ProjectId;

            if (UpdateProjectPhoto(projectWithPastPhotoDto).Success)
            {
                return new SuccessResult(Messages.ProjectGüncellendi);
            }
            return new ErrorResult(Messages.ProjectGüncellenemedi);

        }
        public IResult UpdateProjectPhoto(ProjectWithPastPhotoDto projectWithPastPhotoDto) 
        {
         
            List<ProjectPhoto> projectphotopast = _projectPhotoService.GetAllById(projectWithPastPhotoDto.ProjectId).Data;
            ProjectPhoto projectPhoto = new ProjectPhoto  
            {
                ProjectId = projectWithPastPhotoDto.ProjectId,
                ProjectPhotoUrl = projectWithPastPhotoDto.ProjectPhotoUrl,
                ProjectPhotoId= projectphotopast[0].ProjectPhotoId,
            };
            var result = _projectPhotoService.Update(projectPhoto);
            if (result.Success)
            {
                return new SuccessResult();
            }
            return new ErrorResult("Profil Photo Eklenemedi");

        }
        public Project GetByTitle(Project project)
        {
            return _projectsDal.Get(p=>p.Title==project.Title);
        }

    }
}
