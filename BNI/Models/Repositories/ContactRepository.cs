using AutoMapper;
using BNI.Models.ViewModel;

namespace BNI.Models.Repositories
{
    public interface IContactRepository
    {
        public bool Save(Contact data);
    }
    public class ContactRepository : IContactRepository
    {
        private readonly BNIContext _bniContext;

        public ContactRepository(BNIContext bniContext)
        {
            _bniContext = bniContext;
        }

        public bool Save(Contact data)
        {
            _bniContext.Contacts.Add(data);
            return _bniContext.SaveChanges() > 0;
        }
    }
}