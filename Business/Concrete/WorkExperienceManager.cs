using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class WorkExperienceManager : IWorkExperienceService
    {
        IWorkExperienceDal _workExperienceDal;

        public WorkExperienceManager(IWorkExperienceDal workExperienceDal)
        {
            _workExperienceDal = workExperienceDal;
        }

        public IResult Add(WorkExperience workExperience)
        {
            _workExperienceDal.Add(workExperience);
            return new SuccessResult();

        }

        public IResult Delete(WorkExperience workExperience)
        {
            _workExperienceDal.Delete(workExperience);
            return new SuccessResult();
        }

        public IDataResult<List<WorkExperience>> GetAll()
        {
            return new SuccessDataResult<List<WorkExperience>>(_workExperienceDal.GetAll());
        }

        public IDataResult<WorkExperience> GetById(int id)
        {
            return new SuccessDataResult<WorkExperience>(_workExperienceDal.Get(w=>w.WorkExperienceId==id));
        }

        public IResult Update(WorkExperience workExperience)
        {
            _workExperienceDal.Update(workExperience);
            return new SuccessResult();
        }

        public IResult UpdateWorkExperience(WorkExperienceDto workExperienceDto)
        {
            var result=_workExperienceDal.UpdateWorkExperience(workExperienceDto);
            if (result)
            {
                return new SuccessResult(Messages.UpdateWorkExp);
            }
            return new ErrorResult(Messages.UpdateWorkExpError);
        }
    }
}
