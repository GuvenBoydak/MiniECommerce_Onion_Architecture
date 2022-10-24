using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(IReadRepository<Category> readRepository, IWriteRepository<Category> writeRepository, IUnitOfWork unitOfWork) : base(readRepository, writeRepository, unitOfWork)
        {
        }
    }
}
