using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectPhotoManager : IProjectPhotoService
    {
        IProjectPhotoDal _projectPhotoDal; 

        public ProjectPhotoManager(IProjectPhotoDal projectPhotoDal) 
        {
            _projectPhotoDal=projectPhotoDal;
        }

        public IResult Add(ProjectPhoto projectPhoto)
        {
            _projectPhotoDal.Add(projectPhoto);
            return new SuccessResult();
        }

        public IResult Delete(ProjectPhoto projectPhoto)
        {
            _projectPhotoDal.Delete(projectPhoto);
            return new SuccessResult(); 
        }

        public IDataResult<List<ProjectPhoto>> GetAll()
        {
            return new SuccessDataResult<List<ProjectPhoto>>(_projectPhotoDal.GetAll());
        }

        public IDataResult<ProjectPhoto> GetById(int id)
        {
            return new SuccessDataResult<ProjectPhoto>(_projectPhotoDal.Get(p=>p.ProjectPhotoId==id));
        }

        public IResult Update(ProjectPhoto projectPhoto)
        {
           _projectPhotoDal.Update(projectPhoto);
            return new SuccessResult();
        }
    }
}
