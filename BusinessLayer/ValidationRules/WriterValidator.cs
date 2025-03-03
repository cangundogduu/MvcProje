using Entity.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar adını boş geçemezsiniz.");
            RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar soyadını boş geçemezsiniz.");
            RuleFor(x => x.WriterAbout).NotEmpty().WithMessage("Hakkında kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterTitle).NotEmpty().WithMessage("Ünvan kısmını boş geçemezsiniz.");
            RuleFor(x => x.WriterName).MinimumLength(2).WithMessage("En az 2 karekter giriniz!");
            RuleFor(x => x.WriterSurname).MinimumLength(2).WithMessage("En az 2 karekter giriniz!");
            RuleFor(x => x.WriterTitle).MinimumLength(2).WithMessage("En az 2 karekter giriniz!");
            RuleFor(x => x.WriterName).MaximumLength(50).WithMessage("En fazla 50 karekter giriniz!");
            RuleFor(x => x.WriterSurname).MaximumLength(50).WithMessage("En fazla 50 karekter giriniz!");
            RuleFor(x => x.WriterTitle).MaximumLength(50).WithMessage("En fazla 50 karekter giriniz!");

        }
        
    }
}
