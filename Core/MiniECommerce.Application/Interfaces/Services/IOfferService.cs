using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IOfferService : IBaseService<Offer>
    {
        Task<List<Offer>> GetByOffersOnTheProductAsync(Guid productID);

        Task<List<Offer>> GetByOffersFromAppUserProductsAsync(Guid appUserID);

        Task<List<Offer>> GetByAppUserMadeOffersAsync(Guid appUserID);
    }
}
