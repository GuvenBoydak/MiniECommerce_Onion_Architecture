using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class ProductWriteRepository : WriteRepository<Product>, IWriteProductRepository
    {
        public ProductWriteRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
