using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISubscriptionService
    {
        IDataResult<List<Subscription>> GetAll();

        IDataResult<Subscription> GetById(int id); 

        IResult Add(Subscription subscription); 

        IResult Update(Subscription subscription);

        IResult Delete(Subscription subscription);
    }
}
