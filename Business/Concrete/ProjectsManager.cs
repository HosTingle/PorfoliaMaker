﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectsManager : IProjectsService
    {
        IProjectsDal _projectsDal;

        public ProjectsManager(IProjectsDal projectsDal)
        {
            _projectsDal = projectsDal;
        }

        public List<Projects> GetAll()
        {
            //İş Kodları
            return _projectsDal.GetAll();
        }

        public Projects GetById(int projectId)
        {
            return _projectsDal.Get(c=>c.ProjectId==projectId);
        }
    }
}
