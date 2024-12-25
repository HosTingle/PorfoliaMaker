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
    public class EventManager : IEventService
    {
        IEventDal _eventDal;

        public EventManager(IEventDal eventDal)
        {
            _eventDal = eventDal;
        }

        public IResult Add(Event _event)
        {
            _eventDal.Add(_event);
            return new SuccessResult();
        }

        public IResult Delete(Event _event)
        {
            _eventDal.Delete(_event);
            return new SuccessResult();
        }

        public IDataResult<List<Event>> GetAll()
        {
          
            return new SuccessDataResult<List<Event>>(_eventDal.GetAll());
        }

        public IDataResult<Event> GetById(int id)
        {
            return new SuccessDataResult<Event>(_eventDal.Get(e=>e.EventId == id));
        }

        public IResult Update(Event _event)
        {
             _eventDal.Update(_event);
            return new SuccessResult();
        }
    }
}
