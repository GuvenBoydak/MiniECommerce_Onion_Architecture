using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        protected readonly MiniECommerceDbContext _db;

        public WriteRepository(MiniECommerceDbContext db)
        {
            _db = db;
        }

        public DbSet<T> Table => _db.Set<T>();

        public async Task AddAsync(T entity)
        {
             await Table.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
           T entity = await Table.FindAsync(id);
            entity.Status = DataStatus.Deleted;
        }

        public async Task Update(T entity)
        {
            T updatedEntity = await Table.FindAsync(entity.ID);
            updatedEntity.Status = DataStatus.Updated;
            Table.Update(entity);
        }
    }
}
