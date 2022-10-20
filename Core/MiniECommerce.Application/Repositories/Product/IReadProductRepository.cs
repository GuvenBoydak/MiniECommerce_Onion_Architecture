using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadProductRepository:IWriteRepository<Product>
    {
        Task<List<Product>> GetByAppUserProductsWithOffers(Guid id);
    }
}
