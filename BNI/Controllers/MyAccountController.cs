using Microsoft.AspNetCore.Mvc;

namespace BNI.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult MyAccount()
        {
            return View();
        }
    }
}