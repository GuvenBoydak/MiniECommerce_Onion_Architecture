using FluentValidation;

namespace MiniECommerce.Application
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID alanı boş geçilemez");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Ürün Adı en fazla 100 karakter olmalıdır.").Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖö\s@]*$").WithMessage("Sadece Harf Giriniz.");
            RuleFor(x => x.UnitPrice).InclusiveBetween(0, decimal.MaxValue).WithMessage("Girilen Fiyat sıfırdan büyük olamlı");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Girilen deger en Fazla 500 karakter olmalıdır.")
                .Matches(@"^[a-zA-ZiİçÇşŞğĞÜüÖöIıUuOo\s@]*$").WithMessage("Sadece Harf Giriniz.");
            RuleFor(x => x.CategoryID).NotEmpty().WithMessage("Kategorisi Boş Geçilemez");
        }
    }
}
