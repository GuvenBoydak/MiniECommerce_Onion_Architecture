using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IProductService:IBaseService<Product>
    {
        Task<CustomResponseDto<List<Product>>> GetByOffersOfAppUserProductsAsync(Guid appUserID);

        Task<CustomResponseDto<List<Product>>> GetAppUserProductsAsync(Guid appUserID);

        Task<CustomResponseDto<List<Product>>> GetByCategoryWithProductsAsync(Guid categoryID);
    }
}
