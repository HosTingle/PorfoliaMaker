﻿using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public ProjectManager(IProjectDal projectsDal)
        {
            _projectsDal = projectsDal;
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


        public IDataResult<Project> GetById(int id) 
        {
            return new SuccessDataResult<Project>(_projectsDal.Get(c=>c.ProjectId==id));
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
    }
}
