using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ProjectManager : IProjectService
    {
        IProjectsDal _projectsDal;

        public ProjectManager(IProjectsDal projectsDal)
        {
            _projectsDal = projectsDal;
        }

        public List<Project> GetAll()
        {
            //İş Kodları
            return _projectsDal.GetAll();
        }

        public Project GetById(int projectId)
        {
            return _projectsDal.Get(c=>c.ProjectId==projectId);
        }
    }
}
