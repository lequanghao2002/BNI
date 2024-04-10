using Microsoft.AspNetCore.Mvc;

namespace BNI.Controllers
{
    public class IntroduceController : Controller
    {
        public IActionResult Introduce()
        {
            return View();
        }
    }
}