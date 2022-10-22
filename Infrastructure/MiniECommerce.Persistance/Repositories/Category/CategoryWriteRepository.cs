using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class CategoryWriteRepository : WriteRepository<Category>, IWriteCategoryRepository
    {
        public CategoryWriteRepository(MiniECommerceDbContext db, IUnitOfWork unitOfWork) : base(db, unitOfWork)
        {
        }
    }
}
