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
    public interface IForeignLanguageService
    {
        IDataResult<List<ForeignLanguage>> GetAll();

        IResult Add(ForeignLanguage foreignLanguage);

        IResult Update(ForeignLanguage foreignLanguage);
         
        IResult Delete(ForeignLanguage foreignLanguage);

        IDataResult<ForeignLanguage> GetById(int id);

        IResult UpdateForeignLanguage(ForeignLanguageDto foreignLanguageDto);
    }
}
