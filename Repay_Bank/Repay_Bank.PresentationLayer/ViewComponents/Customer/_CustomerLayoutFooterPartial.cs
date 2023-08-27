using Microsoft.AspNetCore.Mvc;

namespace Repay_Bank.PresentationLayer.ViewComponents.Customer
{
    public class _CustomerLayoutFooterPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        { 
            return View();  
        }
    }
}
