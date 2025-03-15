using Entity.Concrete;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı Boş Geçilemez.");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu Boş Geçilemez.");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj İçeriği Boş Geçilemez.");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Lütfen geçerli bir mail adresi yazınız.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz.");
            RuleFor(x => x.Subject).MaximumLength(100).WithMessage("En fazla 100 karakter girebilirsiniz.");

        }
    }
}
