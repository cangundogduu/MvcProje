using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ContactValidator:AbstractValidator<Contact>
    {
        public ContactValidator()
        {
            RuleFor(x => x.UserEmail).NotEmpty().WithMessage("Mail Adresi Boş Geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Adı Boş Geçilemez");
            RuleFor(x => x.UserName).NotEmpty().WithMessage("Kullanıcı Adı Boş Geçilemez");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.UserName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter girişi yapınız");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayınız");
            RuleFor(x => x.UserName).MaximumLength(50).WithMessage("Lütfen 50 karakterden fazla değer girişi yapmayınız");
            RuleFor(x => x.UserEmail).EmailAddress().WithMessage("Lütfen Geçerli Bir Mail Adresi Giriniz");
        }
    }
}
