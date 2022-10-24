using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class ColorWriteRepository : WriteRepository<Color>, IWriteColorRepository
    {
        public ColorWriteRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
