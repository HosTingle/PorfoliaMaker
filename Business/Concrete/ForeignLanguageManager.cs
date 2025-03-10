using Business.Abstract;
using Business.Constants;
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
    public class ForeignLanguageManager : IForeignLanguageService
    {
        IForeignLanguageDal _foreignLanguage;

        public ForeignLanguageManager(IForeignLanguageDal foreignLanguage)
        {
            _foreignLanguage = foreignLanguage;
        }

        public IResult Add(ForeignLanguage foreignLanguage)
        {
            throw new NotImplementedException();
        }

        public IResult Delete(ForeignLanguage foreignLanguage)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<ForeignLanguage>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<ForeignLanguage> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public IResult Update(ForeignLanguage foreignLanguage)
        {
            throw new NotImplementedException();
        }
        public IResult UpdateForeignLanguage(ForeignLanguageDto foreignLanguageDto)
        {
            var result=_foreignLanguage.UpdateForeignLanguage(foreignLanguageDto);
            if (result)
            {
                return new SuccessResult( Messages.UpdateForeign);
            }
            return new ErrorResult(Messages.UpdateForeignError);
        }
    }
}
