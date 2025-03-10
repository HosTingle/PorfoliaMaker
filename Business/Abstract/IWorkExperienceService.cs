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
    public interface IWorkExperienceService
    {
        IDataResult<List<WorkExperience>> GetAll();

        IResult Add(WorkExperience workExperience); 

        IResult Update(WorkExperience workExperience);

        IResult Delete(WorkExperience workExperience);

        IDataResult<WorkExperience> GetById(int id);

        IResult UpdateWorkExperience(WorkExperienceDto workExperienceDto); 
    }
}
