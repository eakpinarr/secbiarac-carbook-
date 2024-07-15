using CarBook.Application.Features.Mediator.Commands.ReviewCommands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Validators.ReviewValidators
{
    public class UpdateReviewValidator:AbstractValidator<UpdateReviewCommand>
    {
        public UpdateReviewValidator()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen Müşteri Adını Boş Geçmeyiniz");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen En Az 5 Karakter Veri Girişi Yapınız");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen Puan Değerini Boş Geçmeyiniz.");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen Yorum Kısmını Boş Geçmeyiniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen Yorum kısmına en az 50 karakter veri girişi yapınız.");
            RuleFor(x => x.Comment).MaximumLength(500).WithMessage("Lütfen Yorum Kısmına en fazla 500 karakter veri girişi yapınız");
            RuleFor(x => x.CustomerImage).NotEmpty().WithMessage("Lütfen Görseli boş Bırakmayınız.").MinimumLength(10).WithMessage("En az 10 karakter uzunluğunda veri girişi yapınız").MaximumLength(200).WithMessage("En fazla 200 karakter uzunluğunda veri girişi yapınız");
        }
    }
}
