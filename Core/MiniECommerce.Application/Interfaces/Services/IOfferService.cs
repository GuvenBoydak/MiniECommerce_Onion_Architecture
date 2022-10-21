using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IOfferService : IBaseService<Offer>
    {
        Task<List<Offer>> GetByOffersProductIDAsync(Guid id);
    }
}
