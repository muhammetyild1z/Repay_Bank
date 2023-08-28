using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Repay_Bank.BusinessLayer.Concrate;
using Repay_Bank.DTO.DTOS.AppUserDtos;
using Repay_Bank.EntityLayer.Concrete;
using System.Security.Claims;
using System.Xml.Linq;

namespace Repay_Bank.PresentationLayer.Controllers
{
    [Authorize]
    public class MyAccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public MyAccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index(CustomerEditDto customerEditDto)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            // var user = await _userManager.FindByIdAsync(User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).FirstOrDefault().Value);
            customerEditDto.Name = values.CustomerName;
            customerEditDto.Username = values.UserName;
            customerEditDto.Surname = values.CustomerSurname;
            customerEditDto.PhoneNumber = values.PhoneNumber;
            customerEditDto.City = values.City;
            customerEditDto.District = values.District;
            customerEditDto.ImageUrl = values.CustomerImageUrl;
            customerEditDto.Email = values.Email;
            customerEditDto.Password = values.PasswordHash;
            return View(customerEditDto);
        }

        [HttpPost]
        public async Task<IActionResult> Index(CustomerEditDto customerEditDto, int id)
        {

            if (customerEditDto.Password == customerEditDto.ConfirmPassword)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                user.PhoneNumber = customerEditDto.PhoneNumber;
                user.City = customerEditDto.City;
                user.Email = customerEditDto.Email;
                user.Email = user.Email;
                user.District = customerEditDto.District;
                user.CustomerImageUrl = "test";
                user.CustomerSurname = customerEditDto.Surname;
                user.CustomerName = customerEditDto.Name;
                if (customerEditDto.Password == null)
                {
                    user.PasswordHash = user.PasswordHash;
                    
                }
                else
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, customerEditDto.Password);
                }
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    ViewBag.resultFailed = "Islem Basariz Daha sonra tekrar Deneyiniz.";
                }
            }



            else
            {
                ViewBag.Password = "Sifreler uyusmamakta!";
            }

            return View();
        }
    }
}
