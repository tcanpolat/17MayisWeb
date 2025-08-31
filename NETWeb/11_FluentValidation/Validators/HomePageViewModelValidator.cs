using _11_FluentValidation.ViewModels;
using FluentValidation;

namespace _11_FluentValidation.Validators
{
    public class HomePageViewModelValidator : AbstractValidator<HomePageViewModel>
    {
        public HomePageViewModelValidator()
        {
            //RuleFor(vm => vm.Kisi).NotNull().WithMessage("Kişi nesnesi boş olamaz");

            //RuleFor(vm => vm.Adres).NotNull().WithMessage("Adres nesnesi boş olamaz");

            RuleFor(vm => vm.Kisi.Ad)
                .NotEmpty().WithMessage("Ad alanı boş olamaz")
                .NotNull().WithMessage("Ad alanı boş olamaz")
                .Length(1, 50).WithMessage("Ad alanı 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(vm => vm.Kisi.Soyad)
               .NotEmpty().WithMessage("Soyad alanı boş olamaz")
               .Length(1, 50).WithMessage("Soyad alanı 1 ile 50 karakter arasında olmalıdır.");

            RuleFor(vm => vm.Kisi.Yas)
             .NotEmpty().WithMessage("Yaş alanı boş olamaz")
             .GreaterThan(0).WithMessage("Yaş 0'dan büyük olmalıdır")
             .LessThan(120).WithMessage("Yaş 120'den küçük olmalıdır");

            RuleFor(vm => vm.Adres.AdresTanim)
              .NotEmpty().WithMessage("Adres tanım alanı boş olamaz")
              .Length(1, 100).WithMessage("Adres tanım alanı 1 ile 100 karakter arasında olmalıdır.");

            RuleFor(vm => vm.Adres.Sehir)
             .NotEmpty().WithMessage("Sehir alanı boş olamaz")
             .Length(1,50).WithMessage("Sehir alanı 1 ile 50 karakter arasında olmalıdır.");

        }
    }
}
