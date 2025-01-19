using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserRoleService
    {
            
        IDataResult<List<UserRole>> GetAll();

        IResult Add(UserRole userRole); 

        IResult Update(UserRole userRole);

        IResult Delete(UserRole userRole);

        IDataResult<UserRole> GetById(int id);
    }
}
