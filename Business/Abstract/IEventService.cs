using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IEventService
    {
        IDataResult<List<Event>> GetAll();

        IResult Add(Event _event);

        IResult Update(Event _event);

        IResult Delete(Event _event);

        IDataResult<Event> GetById(int id);
    }
}
