using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BNI.Controllers
{
    public class AssignmentController : Controller
    {
        BNIContext _context = new BNIContext();
        // GET: /<controller>/
        public AssignmentController(BNIContext context)
        {
            _context = context;
        }

        // GET: /<controller>/
        public async Task<IActionResult> Index(int id)
        {
            var assignments = await _context.Assignments.Include(a => a.Term).ToListAsync(); // Bao gồm thông tin của Term khi truy vấn

            return View(assignments);
        }
    }
}

