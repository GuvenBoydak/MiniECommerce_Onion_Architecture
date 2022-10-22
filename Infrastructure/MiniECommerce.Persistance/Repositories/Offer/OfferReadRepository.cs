using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class OfferReadRepository : ReadRepository<Offer>, IReadOfferRepository
    {
        public async Task<List<Offer>> GetByAppUserMadeOffersAsync(Guid appUserID)
        {
            return await Table.Where(x => x.AppUserID == appUserID).ToListAsync();
        }

        public async Task<List<Offer>> GetByOffersFromAppUserProductsAsync(Guid appUserID)
        {
            return await Table.Include(x => x.AppUser).ThenInclude(x => x.Products).Where(x => x.AppUserID == appUserID).ToListAsync();
        }

        public async Task<List<Offer>> GetByOffersOnTheProductAsync(Guid productID)
        {
            return await Table.Include(x => x.Product).Where(x => x.ProductID == productID).ToListAsync();
        }
    }
}
