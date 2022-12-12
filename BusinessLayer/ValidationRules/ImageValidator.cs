using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class ImageValidator : AbstractValidator<Image>
    {
        public ImageValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Görsel başlığını boş geçemezsiniz");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Görsel açıklamasını boş geçemezsiniz");
            RuleFor(x => x.ImageUrl).NotEmpty().WithMessage("Görsel yolunu boş geçemezsiniz");

            RuleFor(x => x.Title).MinimumLength(5).WithMessage("Görsel başlığı en az 5 karakter olmalıdır");
            RuleFor(x => x.Title).MaximumLength(20).WithMessage("Görsel başlığı en fazla 20 karakter olmalıdır");
            
            RuleFor(x => x.Description).MinimumLength(10).WithMessage("Görsel açıklaması en az 10 karakter olmalıdır");
            RuleFor(x => x.Description).MaximumLength(50).WithMessage("Görsel açıklaması en fazla 50 karakter olmalıdır");

        }
    }
}
