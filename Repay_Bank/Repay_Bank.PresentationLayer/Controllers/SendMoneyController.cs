using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repay_Bank.BusinessLayer.Abstract;
using Repay_Bank.DataAccessLayer.Concrete;
using Repay_Bank.DTO.DTOS.CustomerAccountProcessDtos;
using Repay_Bank.EntityLayer.Concrete;

namespace Repay_Bank.PresentationLayer.Controllers
{
    public class SendMoneyController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ICustomerAccountProcessService _accountProcessService;

        public SendMoneyController(UserManager<AppUser> userManager, ICustomerAccountProcessService accountProcessService)
        {
            _userManager = userManager;
            _accountProcessService = accountProcessService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(SendMoneyForCustomerAccountProcessDto sendMoneyForCustomerAccountProcessDto)
        {
            //optimize edilecek
            var context = new Context();
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var receiverAccountNumberID = context.CustomerAccounts.Where(x => x.CustomerAccountNumber == sendMoneyForCustomerAccountProcessDto.ReceiverAccountNumber)
                .Select(x => x.CustomerID).FirstOrDefault();


            //sendMoneyForCustomerAccountProcessDto.SenderID = user.Id;
            //sendMoneyForCustomerAccountProcessDto.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            //sendMoneyForCustomerAccountProcessDto.ProcessType = "Havale";

            //automapper guncellenecek
            var values = new CustomerAccountProcess();

            values.ProcessDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            values.SenderID = 1;
            values.ProcessType = "Havale";
            values.ReceiverID = receiverAccountNumberID;
            values.Amount = sendMoneyForCustomerAccountProcessDto.Amount;
             _accountProcessService.TInsert(values);

            return RedirectToAction("Index", "test");
        }
    }
}
