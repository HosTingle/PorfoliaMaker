using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SocialLinkManager : ISocialLinkService
    { 
        ISocialLinkDal _socialLinkDal;

        public SocialLinkManager(ISocialLinkDal socialLinkDal)
        {
            _socialLinkDal = socialLinkDal;
        }

        public IResult Add(SocialLink socialLink)
        {
            _socialLinkDal.Add(socialLink);
            return new SuccessResult();
        }

        public IResult Delete(SocialLink socialLink)
        {
            _socialLinkDal.Delete(socialLink);
            return new SuccessResult(); 
        }

        public IDataResult<List<SocialLink>> GetAll()
        {
            return new SuccessDataResult<List<SocialLink>>(_socialLinkDal.GetAll() );
        }

        public IDataResult<SocialLink> GetById(int id)
        {
            return new SuccessDataResult<SocialLink>(_socialLinkDal.Get(s=>s.SocialLinkId==id));
        }

        public IResult Update(SocialLink socialLink)
        {
            _socialLinkDal.Update(socialLink);
            return new SuccessResult();
        }
    }
}
