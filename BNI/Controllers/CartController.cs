using Microsoft.AspNetCore.Mvc;

namespace BNI.Controllers
{
    public class CartController : Controller
    {
        public IActionResult Cart()
        {
            return View();
        }
    }
}