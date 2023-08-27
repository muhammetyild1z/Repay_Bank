using Microsoft.AspNetCore.Mvc;

namespace Repay_Bank.PresentationLayer.Controllers
{
	public class MyProfileController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
