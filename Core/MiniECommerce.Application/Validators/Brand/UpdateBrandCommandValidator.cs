using FluentValidation;

namespace MiniECommerce.Application
{
    public class UpdateBrandCommandValidator : AbstractValidator<UpdateBrandCommand>
    {
        public UpdateBrandCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID alanı boş geçilemez");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Marka İsmi boş geçilemez").MaximumLength(50).WithMessage("Marka ismi en fazla 50 karakter olamlıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");

        }
    }
}
