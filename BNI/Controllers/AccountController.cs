using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Text.Json;
using System.Threading.Tasks;
using BNI.Common;
using BNI.Models;
using BNI.Models.Repositories;
using BNI.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

            return RedirectToAction("MyAccount");
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
                var emailExists = _accountRepository.CheckEmail(registerVM.Email);
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
                    var userLogin = _accountRepository.Login(new LoginViewModel() { Email = registerVM.Email, Password = registerVM.Password });

                    string userJson = JsonSerializer.Serialize(userLogin);
                    HttpContext.Session.SetString(CommonConstants.SessionUser, userJson);

                    return RedirectToAction("MyAccount");
                }
            }
            return View();
        }
        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ResetPassword(string email)
        {
            var emailExists = _accountRepository.CheckEmail(email);

            if (emailExists)
            {
                var sendEmail = _accountRepository.sendEmailResetPassword(email);

                if(sendEmail)
                {
                    ViewBag.resetSuccess = "Hướng dẫn đặt lại mật khẩu đã được gửi tới email của bạn";
                }
            }
            else
            {
                ViewBag.resetError = "Không tìm thấy tài khoản nào ứng với thông tin đăng nhập này";
            }

            return View();
        }

        public IActionResult EmailResetPassword(ResetPasswordViewModel resetPasswordVM)
        {
            return View(resetPasswordVM);
        }

        [HttpPost]
        public IActionResult EmailResetPassword(RegisterViewModel registerVM)
        {
            var temp = new ResetPasswordViewModel()
            {
                Email = registerVM.Email,
                FullName = registerVM.FullName,
            };


            if (registerVM.Password != registerVM.RePassword)
            {
                ModelState.AddModelError("Password", "Mật khẩu không trùng khớp với nhau");
                return View(temp);
            }

            var resetPassword = _accountRepository.ResetPassword(registerVM);

            if (resetPassword)
            {
                LoginViewModel loginVM = new LoginViewModel
                {
                    Email = registerVM.Email,
                    Password = registerVM.Password,
                };

                var user = _accountRepository.Login(loginVM);
                string userJson = JsonSerializer.Serialize(user);
                HttpContext.Session.SetString(CommonConstants.SessionUser, userJson);

                return RedirectToAction("MyAccount");
            }

            return View(temp);
        }

        public IActionResult MyAccount()
        {
            return View();
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ChangePassword(string oldPassword, string newPassword, string reNewPassword)
        {
            if (newPassword != reNewPassword)
            {
                ModelState.AddModelError("changeError", "Mật khẩu mới không trùng khớp với nhau");
                return View();
            }

            var changePassword = _accountRepository.ChangePassword(oldPassword, newPassword);
            if (changePassword)
            {
                ViewBag.changeSuccess = "Password Updated!";
                return View();
            }
            else
            {
                ModelState.AddModelError("", "Mật khẩu hiện tại không đúng");
                return View();
            }
           
        }

        public IActionResult Information()
        {

            return View()
;       }

        [HttpPost]
        public IActionResult Information(User user)
        {
            var update = _accountRepository.Update(user);

            if (update == false)
            {
                ViewBag.ErrorSuccess = "Lưu thất bại";
                return View();
            }

            var userLogin = _accountRepository.Login(new LoginViewModel() { Email = user.Email,  Password = user.Password });
            string userJson = JsonSerializer.Serialize(user);
            HttpContext.Session.SetString(CommonConstants.SessionUser, userJson);

            ViewBag.UpdateSuccess = "Lưu thành công";
            return View()
;
        }
    }
}

