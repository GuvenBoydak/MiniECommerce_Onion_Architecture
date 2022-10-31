using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class BrandWriteRepository : WriteRepository<Brand>, IWriteBrandRepository
    {
        public BrandWriteRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
