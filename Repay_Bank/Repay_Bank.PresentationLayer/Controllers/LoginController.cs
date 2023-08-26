using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repay_Bank.DTO.DTOS.AppUserDtos;
using Repay_Bank.EntityLayer.Concrete;

namespace Repay_Bank.PresentationLayer.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signinManager;
        private readonly UserManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> signinManager, UserManager<AppUser> userManager)
        {
            _signinManager = signinManager;
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Index(LoginViewModel loginViewModel)
        {
            var result = await _signinManager.PasswordSignInAsync(loginViewModel.Username, loginViewModel.Password, loginViewModel.RememberMe, false);
            if (result.Succeeded)
            {
                var mailCheck = await _userManager.FindByNameAsync(loginViewModel.Username);
				if (mailCheck.EmailConfirmed==true)
				{
					return RedirectToAction("Index", "MyProfile");
                }
                else
                {
                    @TempData["UserId"] = mailCheck.Id;
                    
                    return RedirectToAction("MailConfirmed", "Register");
                }
				
                
            }
            return View();
        }
    }
}
