using Microsoft.AspNetCore.Mvc;

namespace Repay_Bank.PresentationLayer.Controllers
{
	public class CustomerLayoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
