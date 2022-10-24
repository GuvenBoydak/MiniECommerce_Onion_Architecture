using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IOfferService : IBaseService<Offer>
    {
        Task<CustomResponseDto<List<Offer>>> GetByOffersOnTheProductAsync(Guid productID);

        Task<CustomResponseDto<List<Offer>>> GetByOffersFromAppUserProductsAsync(Guid appUserID);

        Task<CustomResponseDto<List<Offer>>> GetByAppUserMadeOffersAsync(Guid appUserID);
    }
}
