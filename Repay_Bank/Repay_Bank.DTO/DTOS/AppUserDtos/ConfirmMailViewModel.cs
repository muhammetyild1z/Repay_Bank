using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.DTO.DTOS.AppUserDtos
{
    public class ConfirmMailViewModel
    {
        public string UserId { get; set; }
        public int ConfirmCode { get; set; }
    }
}
