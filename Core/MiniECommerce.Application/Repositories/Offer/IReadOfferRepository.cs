using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadOfferRepository:IWriteRepository<Offer>
    {
        Task<List<Offer>> GetByOffersProductIDAsync(Guid id);
    }
}
