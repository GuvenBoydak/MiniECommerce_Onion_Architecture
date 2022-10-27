using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private readonly IReadOfferRepository _readOfferRepository;

        public OfferService(IReadOfferRepository readOfferRepository, IWriteRepository<Offer> writeRepository, IUnitOfWork unitOfWork) : base(readOfferRepository, writeRepository)
        {
            _readOfferRepository = readOfferRepository;
        }

        public async Task<List<Offer>> GetByAppUserMadeOffersAsync(Guid appUserID)
        {
            return await _readOfferRepository.GetByAppUserMadeOffersAsync(appUserID);
        }

        public async Task<List<Offer>> GetByOffersFromAppUserProductsAsync(Guid appUserID)
        {
            return await _readOfferRepository.GetByOffersFromAppUserProductsAsync(appUserID); ;
        }

        public async Task<List<Offer>> GetByOffersOnTheProductAsync(Guid productID)
        {
            return await _readOfferRepository.GetByOffersOnTheProductAsync(productID);
        }
    }
}
