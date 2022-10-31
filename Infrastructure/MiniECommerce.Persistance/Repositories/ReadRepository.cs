using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Persistance
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        protected readonly MiniECommerceDbContext _db;

        public ReadRepository(MiniECommerceDbContext db)
        {
            _db = db;
        }

        public DbSet<T> Table => _db.Set<T>();

        public IQueryable<T> GetActive()
        {
            return Where(x => x.Status != DataStatus.Deleted);
        }

        public IQueryable<T> GetAll()
        {
            var query = Table.AsNoTracking();
            return query.AsQueryable();
        }

        public Task<T> GetByFirstAsync(Expression<Func<T, bool>> filter)
        {
            var query = Table.AsNoTracking();
            return query.FirstOrDefaultAsync(filter);
        }

        public Task<T> GetByIDAsync(Guid ID)
        {
            var query = Table.AsNoTracking();
            return query.FirstOrDefaultAsync(x => x.ID == ID);
        }

        public IQueryable<T> GetPassive()
        {
            return Where(x => x.Status != DataStatus.Deleted);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> filter)
        {
            var query = Table.AsNoTracking();
            return query.Where(filter).AsQueryable();
        }
    }
}
