using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class OfferService : BaseService<Offer>, IOfferService
    {
        private readonly IReadOfferRepository _readOfferRepository;
        private readonly IWriteOfferRepository _writeOfferRepository;
        private readonly IReadProductRepository _readProductRepository;
        private readonly IWriteProductRepository _writeProductRepository;

        public OfferService(IReadOfferRepository readOfferRepository, IWriteRepository<Offer> writeRepository, IUnitOfWork unitOfWork, IReadProductRepository readProductRepository, IWriteProductRepository writeProductRepository, IWriteOfferRepository writeOfferRepository) : base(readOfferRepository, writeRepository)
        {
            _readOfferRepository = readOfferRepository;
            _readProductRepository = readProductRepository;
            _writeProductRepository = writeProductRepository;
            _writeOfferRepository = writeOfferRepository;
        }

        public async Task BuyProductAsync(Offer offer)
        {
            Product product = await _readProductRepository.GetByIDAsync(offer.ProductID);
            if (product.IsSold != true)
            {
                product.IsSold = true;
                product.IsOfferable = false;
                await _writeProductRepository.Update(product);//Ürün bilgilerini güncelliyoruz.

                offer.Price = product.UnitPrice;
                await _writeOfferRepository.AddAsync(offer);//Satın Alım teklifini kaydediyoruz.

                List<Offer> offers = await _readOfferRepository.GetByOffersOnTheProductAsync(offer.ProductID);//İlgili üründeki tüm Offerları siliyoruz.
                foreach (Offer item in offers)
                {
                    if (item.DeletedDate == null)
                        await _writeOfferRepository.DeleteAsync(item.ID);
                }
            }
            else
                throw new Exception("Can't buy this product");
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

        public async Task OfferApprovalAsync(Offer offer)
        {
            //Teklif Onaylandıysa ilgili Ürünün bilgilerini güncelliyoruz.
            if (offer.IsApproved == true)
                await _writeOfferRepository.Update(offer);

            Product product = await _readProductRepository.GetByIDAsync(offer.ProductID);
            product.IsSold = true;
            product.IsOfferable = false;
            product.AppUserID = offer.AppUserID;
            product.UnitPrice = offer.Price;
            await _writeProductRepository.Update(product);

            List<Offer> offers = await _readOfferRepository.GetByOffersOnTheProductAsync(offer.ProductID);//İlgili üründeki tüm Offerları siliyoruz.
            foreach (Offer item in offers)
            {
                await DeleteAsync(item.ID);
            }
        }
    }
}
