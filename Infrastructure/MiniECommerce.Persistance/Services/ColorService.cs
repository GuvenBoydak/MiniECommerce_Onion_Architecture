using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class ColorService : BaseService<Color>, IColorService
    {
        public ColorService(IReadRepository<Color> readRepository, IWriteRepository<Color> writeRepository, IUnitOfWork unitOfWork) : base(readRepository, writeRepository)
        {
        }
    }
}
