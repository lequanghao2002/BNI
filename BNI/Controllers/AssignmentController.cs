﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BNI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class AssignmentController : Controller
    {
        BNIContext _context = new BNIContext();
        // GET: /<controller>/
        public IActionResult Index()
        {
            var assignment = _context.Assignments.ToList();

            return View(assignment);
        }
    }
}
