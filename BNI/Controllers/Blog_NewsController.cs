using Microsoft.AspNetCore.Mvc;

namespace BNI.Controllers
{
    public class Blog_NewsController : Controller
    {
        public IActionResult Blog_News()
        {
            return View();
        }
    }
}