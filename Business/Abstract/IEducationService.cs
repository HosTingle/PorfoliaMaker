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
    public interface IEducationService
    {
        IDataResult<List<EducationInfo>> GetAll();

        IResult Add(EducationInfo educationInfo);

        IResult Update(EducationInfo educationInfo);

        IResult Delete(EducationInfo educationInfo);

        IDataResult<EducationInfo> GetById(int id);

        IResult UpdateEducation(EducationInfoDto educationInfoDto);

        IDataResult<List<EducationInfo>> GetByUserId(int id);
    }
}
