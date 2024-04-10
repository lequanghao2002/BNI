using Microsoft.AspNetCore.Mvc;

namespace BNI.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Product()
        {
            return View();
        }
    }
}