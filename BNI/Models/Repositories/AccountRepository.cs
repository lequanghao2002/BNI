using AutoMapper;
using BNI.Common;
using BNI.Models.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Data;

namespace BNI.Models.Repositories
{
    public interface IAccountRepository
    {
        public User Login(LoginViewModel loginVM);
        public bool Register(RegisterViewModel registerVM);
        public bool CheckEmail(string email);
        public bool sendEmailResetPassword(string email);
        public bool ResetPassword(RegisterViewModel registerViewModel);
        public bool ChangePassword(string oldPassword, string newPassword);
        public bool Update (User user);
    }
    public class AccountRepository : IAccountRepository
    {
        private readonly BNIContext _bniContext;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AccountRepository(BNIContext bniContext, IMapper mapper, IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor) {
            _bniContext = bniContext;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _httpContextAccessor = httpContextAccessor;
        }

        public User Login(LoginViewModel loginVM)
        {
            var findAccount = _bniContext.Users.SingleOrDefault(u => u.Email == loginVM.Email && u.Password == loginVM.Password);

            return findAccount;
        }

        public bool CheckEmail(string email)
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

        public bool sendEmailResetPassword(string email)
        {
            var user = _bniContext.Users.Single(u => u.Email == email);

            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePath = Path.Combine(webRootPath, "template/resetPasswordTemplate.html");

            string templateContent = File.ReadAllText(filePath);
            templateContent = templateContent.Replace("{{fullName}}", user.FullName);
            templateContent = templateContent.Replace("{{email}}", user.Email);
            EmailService.SendMail("BNI", "Lấy lại mật khẩu", templateContent, user.Email);

            return true;
        }

        public bool ResetPassword(RegisterViewModel registerViewModel)
        {
            var user = _bniContext.Users.Single(u => u.Email == registerViewModel.Email);

            user.Password = registerViewModel.Password;
            _bniContext.SaveChanges();

            return true;
        }

        public bool ChangePassword(string oldPassword, string newPassword)
        {
            string userJson = _httpContextAccessor.HttpContext.Session.GetString(CommonConstants.SessionUser);
            if (userJson != null)
            {
                var user = JsonConvert.DeserializeObject<User>(userJson);
                
                if(user.Password == oldPassword)
                {
                    user.Password = newPassword;
                    _bniContext.SaveChanges();
                    return true;
                }
            }

            return false;
        }

        public bool Update(User user)
        {
            var userById = _bniContext.Users.SingleOrDefault(u => u.Id == user.Id);
            if (userById != null)
            {
                userById.FullName = user.FullName;
                userById.Email = user.Email;
                userById.Company = user.Company;
                userById.Vat = user.Vat;
                userById.PhoneNumber = user.PhoneNumber;
                userById.Address = user.Address;
                userById.City = user.City;
                userById.Zip = user.Zip;
                userById.Country = user.Country;

                _bniContext.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
