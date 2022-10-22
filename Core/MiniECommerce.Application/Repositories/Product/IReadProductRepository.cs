using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadProductRepository:IWriteRepository<Product>
    {
        Task<List<Product>> GetByOffersOfAppUserProductsAsync(Guid appUserID);

        Task<List<Product>> GetAppUserProductsAsync(Guid id);
    }
}
