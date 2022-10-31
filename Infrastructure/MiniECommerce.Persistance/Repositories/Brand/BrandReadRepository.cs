using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class BrandReadRepository : ReadRepository<Brand>, IReadBrandRepository
    {
        public BrandReadRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
