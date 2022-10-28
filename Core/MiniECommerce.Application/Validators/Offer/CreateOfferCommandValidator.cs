using FluentValidation;

namespace MiniECommerce.Application
{
    public class CreateOfferCommandValidator:AbstractValidator<CreateOfferCommand>
    {
        public CreateOfferCommandValidator()
        {
            RuleFor(x => x.Price).NotEmpty().WithMessage("Fiyat alanı boş olamamalı").GreaterThan(0).WithMessage("Fiyat alanı sıfırdan büyük olmalıdır");
            RuleFor(x => x.ProductID).NotEmpty().WithMessage("Ürün alanı boş olamamalı");
        }
    }
}
