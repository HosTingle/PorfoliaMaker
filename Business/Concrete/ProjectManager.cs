using Business.Abstract;
using Core.Utilities.Results;
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

        public List<Project> GetAll()
        { 
            //İş Kodları
            return _projectsDal.GetAll();
        }

        public Project GetById(int id) 
        {
            return _projectsDal.Get(c=>c.ProjectId==id);
        }

        public IResult Update(Project project)
        {
            _projectsDal.Update(project);
            return new SuccessResult();
        }
    }
}
