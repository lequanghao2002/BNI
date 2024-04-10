using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using BNI.Common;
using BNI.Models;
using BNI.Models.Repositories;
using BNI.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel loginVM)
        {
            var user = _accountRepository.Login(loginVM);
            if(user == null)
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng");
                return View();
            }

            string userJson = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString(CommonConstants.SessionUser, userJson);

            return RedirectToAction("Index", "Home");
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(CommonConstants.SessionUser);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(RegisterViewModel registerVM)
        {
            if (ModelState.IsValid)
            {
                var emailExists = _accountRepository.checkEmail(registerVM.Email);
                if (emailExists == true)
                {
                    ModelState.AddModelError("Email", "Email này đã tồn tại");
                    return View(registerVM);
                }

                if (registerVM.Password != registerVM.RePassword)
                {
                    ModelState.AddModelError("Password", "Mật khẩu không trùng khớp với nhau");
                    return View(registerVM);
                }

                var userRegister = _accountRepository.Register(registerVM);

                if (userRegister == true)
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }
    }
}

