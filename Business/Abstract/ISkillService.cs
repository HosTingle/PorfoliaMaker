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
    public interface ISkillService
    {
        IDataResult<List<Skill>> GetAll();

        IResult Add(Skill skill); 

        IResult Update(Skill skill);

        IResult Delete(Skill skill);

        IDataResult<Skill> GetById(int id);

        IDataResult<List<Skill>> GetAlById(int id);

        IResult UpdateSkills(UserInfoAboutDto userInfoAboutDto);
    }
}
