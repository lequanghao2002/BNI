using AutoMapper;
using BNI.Models.ViewModel;

namespace BNI.Models.Repositories
{
    public interface IEventsRegisterRepository
    {
        public bool Save(EventsRegister data);
    }
    public class EventsRegisterRepository : IEventsRegisterRepository
    {
        private readonly BNIContext _bniContext;

        public EventsRegisterRepository(BNIContext bniContext)
        {
            _bniContext = bniContext;
        }

        public bool Save(EventsRegister data)
        {
            _bniContext.EventsRegisters.Add(data);
            return _bniContext.SaveChanges() > 0;
        }

    }
}