using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using Repay_Bank.DTO.DTOS.AppUserDtos;
using Repay_Bank.EntityLayer.Concrete;

namespace Repay_Bank.PresentationLayer.Controllers
{
    public class RegisterController : Controller
    {


        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(AppUserRegisterDto appUserRegisterDto)
        {
            if (ModelState.IsValid)
            {


                AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    CustomerName = appUserRegisterDto.Name,
                    CustomerSurname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    District = "s",
                    CustomerImageUrl = "s",
                    City = "s"


                };
                var emailCheck = await _userManager.FindByEmailAsync(appUser.Email);
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);

                if (result.Succeeded && emailCheck == null)
                {

                    TempData["userId"] = appUser.Id;
                    return RedirectToAction("MailConfirmed", "Register");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                    return View();
                }

            }
            return View();
        }
        [HttpGet]
        public IActionResult MailConfirmed()
        {
            return View();
        }

       
        [HttpPost]
        public async Task<IActionResult> MailConfirmed(ConfirmMailViewModel confirmMailViewModel)
        {
            Random rnd = new Random();
            int code = rnd.Next(100000, 1000000);
           
            var appUser = await _userManager.FindByIdAsync(confirmMailViewModel.UserId);


            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailboxAddressFrom = new MailboxAddress("Replay Bank Admin", "mydzl1200@gmail.com");
            MailboxAddress mailboxAddresstTo = new MailboxAddress("User", appUser.Email);
            mimeMessage.From.Add(mailboxAddressFrom);
            mimeMessage.To.Add(mailboxAddresstTo);


            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = "Merhaba" + appUser.UserName + "," + String.Format(">>>>")
            + "Kayit Olmak Icin Onay Kodu:" + code;
            mimeMessage.Body = bodyBuilder.ToMessageBody();

            mimeMessage.Subject = "Replay Bank Onay Kodu";

            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mydzl1200@gmail.com", "uisorzsawqhcjlih");
            client.Send(mimeMessage);
            client.Disconnect(true);
            TempData["UserId"] = confirmMailViewModel.UserId;
            TempData["code"] = code;
           
            return View();


        }


        [HttpPost]
        public async Task<IActionResult> ConfirmMail(ConfirmMailViewModel confirmMailViewModel)
        {


            var user = await _userManager.FindByIdAsync(confirmMailViewModel.UserId);
            if ( confirmMailViewModel.code== confirmMailViewModel.ConfirmCode)
            {
                user.ConfirmCode = confirmMailViewModel.code;
                user.EmailConfirmed = true;
                await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");

            }

            return View();
        }
    }
}
