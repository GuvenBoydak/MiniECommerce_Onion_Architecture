using FluentValidation;

namespace MiniECommerce.Application
{
    public class UpdateColorCommandValidator : AbstractValidator<UpdateColorCommand>
    {
        public UpdateColorCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID alanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Renk İsmi boş geçilemez").MaximumLength(50).WithMessage("Renk ismi en fazla 40 karakter olamlıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");
        }
    }
}
