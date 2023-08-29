using FluentValidation;
using Repay_Bank.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.BusinessLayer.ValidationRules.CustomerAccountValidationRules
{
    public class CustomerAccountValidator:AbstractValidator<CustomerAccount>
    {
        public CustomerAccountValidator()
        {
            RuleFor(x => x.CustomerAccountNumber).NotEmpty().WithMessage("bos gecilemez.")
                .Length(8).WithMessage("Hesap Numarasi En Fazla 8 Karakarter Olabilir.");
        }
    }
}
