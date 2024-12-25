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
    public class SubscriptionManager : ISubscriptionService
    {
        ISubscriptionDal _subscriptionDal;

        public SubscriptionManager(ISubscriptionDal subscriptionDal)
        {
            _subscriptionDal = subscriptionDal;
        }

        public IResult Add(Subscription subscription)
        {
            _subscriptionDal.Add(subscription);
            return new SuccessResult();
        }

        public IResult Delete(Subscription subscription)
        {
            _subscriptionDal.Delete(subscription);

            return new SuccessResult();
        }

        public IDataResult<List<Subscription>> GetAll()
        {
            return new SuccessDataResult<List<Subscription>>(_subscriptionDal.GetAll());
        }

        public IDataResult<Subscription> GetById(int id) 
        {
            return new SuccessDataResult<Subscription>(_subscriptionDal.Get(s=>s.SubscriptionId==id));
        }

        public IResult Update(Subscription subscription)
        {
            throw new NotImplementedException();
        }
    }
}
