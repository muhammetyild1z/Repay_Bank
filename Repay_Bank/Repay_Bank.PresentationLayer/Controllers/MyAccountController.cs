using Microsoft.AspNetCore.Mvc;

namespace Repay_Bank.PresentationLayer.Controllers
{
    public class MyAccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
