using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IProductService:IBaseService<Product>
    {
        Task<List<Product>> GetByAppUserProductsWithOffers(Guid id);
    }
}
