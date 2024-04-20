using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BNI.Models;
using BNI.Models.Repositories;
using BNI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        //private readonly BNIContext _bniContext;
        public ContactController(IContactRepository contactRepository/*, BNIContext bniContext*/)
        {
            _contactRepository = contactRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact data)
        {
            bool is_success = false;

            is_success = _contactRepository.Save(data);

            if (is_success)
                return RedirectToAction("Index", "Contact");

            return View("Loi luu data");
        }
    }
}