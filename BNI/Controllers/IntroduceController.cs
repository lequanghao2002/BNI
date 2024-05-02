using BNI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BNI.Controllers
{
    public class IntroduceController : Controller
    {
        BNIContext _context = new BNIContext();
        public IntroduceController(BNIContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var introduced = await _context.Assignments.Include(a => a.Term).Include(a => a.Member).ToListAsync();
            ViewBag.latestTerm = await _context.Terms.OrderByDescending(x => x.StartDate).FirstOrDefaultAsync(); ;

            return View(introduced);
        }
    }
}