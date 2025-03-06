using Business.Abstract;
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
    public class SkillManager : ISkillService
    {
        ISkillDal _skillDal;

        public SkillManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public IResult Add(Skill skill)
        {
            _skillDal.Add(skill);
            return new SuccessResult();
        }

        public IResult Delete(Skill skill)
        {
            _skillDal.Delete(skill);
            return new SuccessResult();
        }

        public IDataResult<List<Skill>> GetAll()
        {
            return new SuccessDataResult<List<Skill>>( _skillDal.GetAll());
        }

        public IDataResult<Skill> GetById(int id)
        {
            return new SuccessDataResult<Skill>(_skillDal.Get(s=>s.SkillId == id)); 

        }

        public IResult Update(Skill skill)
        {
            _skillDal.Update(skill);
            return new SuccessResult();
        }
        public IDataResult<List<Skill>> GetAlById(int id) 
        {
            return new SuccessDataResult<List<Skill>>(_skillDal.GetAll(s=>s.UserId==id));
        }

        public IResult UpdateSkills(UserInfoAboutDto userInfoAboutDto)
        {
            throw new NotImplementedException();
        }
    }
}
