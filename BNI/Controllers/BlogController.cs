using Microsoft.AspNetCore.Mvc;

namespace BNI.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Blog()
        {
            return View();
        }
    }
}
