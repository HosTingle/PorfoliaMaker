
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
    public interface IProjectService
    {
        IDataResult<List<Project>> GetAll();
        IDataResult<List<Project>> GetByUserId(int id);

        IDataResult<Project> GetById(int id); 

        IResult Add(Project project);

        IResult Update(Project project);

        IResult Delete(Project project);

        IResult AddPhotoWithProject(ProjectWithPhotoDto projectWithPhotoDto);

        IDataResult<List<ProjectWithPhotoDto>> GetProjectDetailByUserId(int userId);
        IDataResult<List<ProjectDto>> GetAllProjectWithPhotos(int id);

        IResult UpdatePhotoWithProject(ProjectWithPastPhotoDto projectWithPastPhotoDto);
        IResult DeletePhototWithProject(ProjectWithPastPhotoDto projectWithPastPhotoDto);
    }
}
