using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadCategoryRepository:IReadRepository<Category>
    {
        Task<Category> GetByCategoryWithProductsAsync(Guid id);
    }
}
