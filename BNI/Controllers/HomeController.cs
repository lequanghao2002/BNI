using BNI.Models;
using BNI.Models.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using X.PagedList;

namespace BNI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        BNIContext _context = new BNIContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var blogs = _context.Posts.ToList();
            var professions = _context.Professions.ToList();
            var members = _context.Members.ToList();

            var viewModel = new HomeViewModel
            {
                Blogs = blogs,
                Professions = professions,
                Members = members
            };

            return View(viewModel);
        }

        public IActionResult ProfessionDetail(int id)
        {
            var ev = _context.Professions.SingleOrDefault(x => x.Id == id);
            var imgev = _context.Professions.Where(x => x.Id == id).Select(x => x.Image).FirstOrDefault();
            ViewBag.imgev = imgev;

            ViewData["members"] = _context.Members.Where(s => s.ProfessionId == id).ToList();
            ViewData["details"] = _context.ProfessionDetails.Where(s => s.ProfessionId == id).ToList();
            ViewData["related"] = _context.Professions.ToList();

            return View(ev);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}