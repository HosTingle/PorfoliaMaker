using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IProjectPhotoService
    {
        IDataResult<List<ProjectPhoto>> GetAll();

        IResult Add(ProjectPhoto projectPhoto);

        IResult Update(ProjectPhoto projectPhoto);

        IResult Delete(ProjectPhoto projectPhoto);

        IDataResult<ProjectPhoto> GetById(int id);

        IDataResult<List<ProjectPhoto>> GetAllById(int id); 
    }
}
