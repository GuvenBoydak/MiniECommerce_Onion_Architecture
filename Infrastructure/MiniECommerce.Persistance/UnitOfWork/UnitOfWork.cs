using MiniECommerce.Application;

namespace MiniECommerce.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MiniECommerceDbContext _db;

        public UnitOfWork(MiniECommerceDbContext db)
        {
            _db = db;
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
