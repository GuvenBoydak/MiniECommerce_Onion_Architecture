using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class BrandService : BaseService<Brand>, IBrandService
    {
        public BrandService(IReadRepository<Brand> readRepository, IWriteRepository<Brand> writeRepository, IUnitOfWork unitOfWork) : base(readRepository, writeRepository, unitOfWork)
        {
        }
    }
}
