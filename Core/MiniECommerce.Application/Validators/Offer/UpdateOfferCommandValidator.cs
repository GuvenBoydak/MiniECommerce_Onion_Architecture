using FluentValidation;

namespace MiniECommerce.Application
{
    public class UpdateOfferCommandValidator : AbstractValidator<UpdateOfferCommand>
    {
        public UpdateOfferCommandValidator()
        {
            RuleFor(x => x.ID).NotEmpty().WithMessage("ID alanı boş geçilemez");
            RuleFor(x => x.Price).InclusiveBetween(0, int.MaxValue).WithMessage("Fiyat alanı sıfırdan büyük olmalıdır");
        }
    }
}
