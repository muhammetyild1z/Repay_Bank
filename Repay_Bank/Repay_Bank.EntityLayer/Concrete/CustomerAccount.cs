using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.EntityLayer.Concrete
{
    public class CustomerAccount
    {
        [Key]
        public int CustomerID { get; set; }
        public string CustomerAccountNumber { get; set; }
        public string CustomerAccountCurrency { get; set; } //döviz türü
        public decimal CustomerAccountBalance { get; set; }
        public string BankBranch { get; set; }//şube
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
