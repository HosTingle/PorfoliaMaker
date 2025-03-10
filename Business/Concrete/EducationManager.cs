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
    public class EducationManager : IEducationService
    {
        IEducationInfoDal _educationInfoDal;

        public EducationManager(IEducationInfoDal educationInfoDal)
        {
            _educationInfoDal = educationInfoDal;
        }

        public IResult Add(EducationInfo educationInfo)
        {
            _educationInfoDal.Add(educationInfo);
            return new SuccessResult();
        }

        public IResult Delete(EducationInfo educationInfo)
        {
            _educationInfoDal.Delete(educationInfo);
            return new SuccessResult();
        }

        public IDataResult<List<EducationInfo>> GetAll()
        {
            return new SuccessDataResult<List<EducationInfo>>(_educationInfoDal.GetAll());
        }

        public IDataResult<EducationInfo> GetById(int id)
        {
            return new SuccessDataResult<EducationInfo>(_educationInfoDal.Get(e=>e.EducationInfoId==id));
        }
        public IDataResult<List<EducationInfo>> GetByUserId(int id)
        {
            return new SuccessDataResult<List<EducationInfo>>(_educationInfoDal.GetAll(e => e.UserId == id));
        }
        public IResult Update(EducationInfo educationInfo)
        {
            _educationInfoDal.Update(educationInfo);
            return new SuccessResult();
        }

        public IResult UpdateEducation(EducationInfoDto educationInfoDto)
        {
            var result=_educationInfoDal.UpdateEducation(educationInfoDto);
            if (result) 
            {
                return new SuccessResult(Messages.UpdateEducation);
            }
            return new ErrorResult(Messages.UpdateErrorEducation);
                
        }
    }
}
