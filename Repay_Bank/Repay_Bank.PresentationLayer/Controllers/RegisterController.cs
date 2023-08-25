using MailKit.Net.Smtp;
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
                 Random rnd= new Random();
                int code;
                code = rnd.Next(100000, 1000000);

				AppUser appUser = new AppUser()
                {
                    UserName = appUserRegisterDto.Username,
                    CustomerName = appUserRegisterDto.Name,
                    CustomerSurname = appUserRegisterDto.Surname,
                    Email = appUserRegisterDto.Email,
                    ConfirmCode=code,
                    District="s",
                    CustomerImageUrl="s",
                    City="s"
                    
                    
                };
                var result = await _userManager.CreateAsync(appUser, appUserRegisterDto.Password);
                if (result.Succeeded)
                {
                   MimeMessage mimeMessage= new MimeMessage();
                    MailboxAddress mailboxAddressFrom = new MailboxAddress("Replay Bank Admin", "mydzl1200@gmail.com");
                    MailboxAddress mailboxAddresstTo = new MailboxAddress("User", appUser.Email);
                    mimeMessage.From.Add(mailboxAddressFrom);
                    mimeMessage.To.Add(mailboxAddresstTo);

                    var bodyBuilder = new BodyBuilder();
                    bodyBuilder.TextBody = "Kayit Olmak Icin Onay Kodu:" + code;
                    mimeMessage.Body = bodyBuilder.ToMessageBody();

                    mimeMessage.Subject = "Replay Bank Onay Kodu";

                    SmtpClient client= new SmtpClient();
                    client.Connect("smtp.gmail.com",587,false);
                    return RedirectToAction("Index","Confirmmail");
                    client.Authenticate("mydzl1200@gmail.com", "uisorzsawqhcjlih ");
                    client.Send(mimeMessage);
                    client.Disconnect(true);
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
    }
}
