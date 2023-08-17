using FluentValidation;
using Repay_Bank.DTO.DTOS.AppUserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repay_Bank.BusinessLayer.ValidationRules.AppUserValidationRules
{
    public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDto>
    {
        public AppUserRegisterValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Ad alani bos gecilemez.").MaximumLength(20).WithMessage("en fazla 30 karakter olmalidir.");
            RuleFor(x => x.Surname).NotEmpty().WithMessage("soyad alani bos gecilemez.");
            RuleFor(x => x.Password).NotEmpty().WithMessage("sifre alani bos gecilemez."); 
            RuleFor(x => x.ConfirmPassword).NotEmpty().WithMessage("sifre tekrar alani bos gecilemez.").Equal(x=>x.Password).WithMessage("parolalar eslesmiyor."); 
            RuleFor(x => x.Username).NotEmpty().WithMessage("kullaniciadi alani bos gecilemez.");
            RuleFor(x => x.Email).NotEmpty().WithMessage("mail alani bos gecilemez.").EmailAddress().WithMessage("gereceli mail adresi girin.");
        }
    }
}
