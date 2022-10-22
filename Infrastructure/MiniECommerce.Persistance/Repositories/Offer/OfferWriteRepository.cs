using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class OfferWriteRepository : WriteRepository<Offer>, IWriteOfferRepository
    {
        public OfferWriteRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
