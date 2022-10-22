using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class ProductReadRepository : ReadRepository<Product>, IReadProductRepository
    {
        public async Task<List<Product>> GetAppUserProductsAsync(Guid appUserID)
        {
            return await Table.Where(x => x.AppUserID == appUserID).ToListAsync();
        }

        public async Task<List<Product>> GetByCategoryWithProductsAsync(Guid categoryID)
        {
            return await Table.Where(x => x.CategoryID == categoryID).ToListAsync();
        }

        public async Task<List<Product>> GetByOffersOfAppUserProductsAsync(Guid appUserID)
        {
            return await Table.Include(x => x.Offers).Where(x => x.AppUserID == appUserID).ToListAsync();
        }
    }
}
