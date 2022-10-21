using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface ICategoryService : IBaseService<Category>
    {
        Task<Category> GetCategoryWithProductsAsync(Guid id);
    }
}
