using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IProductService:IBaseService<Product>
    {
        Task<List<Product>> GetByOffersOfAppUserProductsAsync(Guid appUserID);

        Task<List<Product>> GetAppUserProductsAsync(Guid appUserID);

        Task<List<Product>> GetByCategoryWithProductsAsync(Guid categoryID);
    }
}
