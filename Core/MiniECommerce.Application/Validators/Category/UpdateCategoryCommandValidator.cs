using FluentValidation;

namespace MiniECommerce.Application
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(50).WithMessage("Kategori ismi en fazla 50 karakter olamlıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Girilen deger en Fazla 500 karakter olmalıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");

        }
    }
}
