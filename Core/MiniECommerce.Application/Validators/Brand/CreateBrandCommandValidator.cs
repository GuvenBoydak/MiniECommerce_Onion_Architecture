using FluentValidation;

namespace MiniECommerce.Application
{
    public class CreateBrandCommandValidator:AbstractValidator<CreateBrandCommand>
    {
        public CreateBrandCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Marka İsmi boş geçilemez").MaximumLength(50).WithMessage("Marka ismi en fazla 50 karakter olamlıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");
        }
    }
}
