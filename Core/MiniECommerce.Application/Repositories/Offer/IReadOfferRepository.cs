using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadOfferRepository:IWriteRepository<Offer>
    {
        Task<List<Offer>> GetByOffersOnTheProductAsync(Guid productID);

        Task<List<Offer>> GetByOffersFromAppUserProductsAsync(Guid appUserID);

        Task<List<Offer>> GetByAppUserMadeOffersAsync(Guid appUserID);
    }
}
