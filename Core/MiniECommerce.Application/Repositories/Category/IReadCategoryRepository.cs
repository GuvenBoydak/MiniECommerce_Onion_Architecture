using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IReadCategoryRepository:IReadRepository<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(Guid id);
    }
}
