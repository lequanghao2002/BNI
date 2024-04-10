using AutoMapper;
using BNI.Models.ViewModel;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace BNI.Models.Repositories
{
    public interface IAccountRepository
    {
        public User Login(LoginViewModel loginVM);
        public bool Register(RegisterViewModel registerVM);
        public bool checkEmail(string email);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly BNIContext _bniContext;
        private readonly IMapper _mapper;

        public AccountRepository(BNIContext bniContext, IMapper mapper) {
            _bniContext = bniContext;
            _mapper = mapper;
        }

        public User Login(LoginViewModel loginVM)
        {
            var findAccount = _bniContext.Users.SingleOrDefault(u => u.Email == loginVM.Email && u.Password == loginVM.Password);

            return findAccount;
        }

        public bool checkEmail(string email)
        {
            var emailExists = _bniContext.Users.SingleOrDefault(u => u.Email == email);

            if (emailExists == null)
            {
                return false;
            }

            return true;
        }

        public bool Register(RegisterViewModel registerVM)
        {
            var registerUser = _mapper.Map<User>(registerVM);
            
            _bniContext.Users.Add(registerUser);
            _bniContext.SaveChanges();

            return true;
        }
    }
}
