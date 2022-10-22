using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IWriteRepository<T> :IRepository<T> where T : BaseEntity
    {
       Task AddAsync(T entity);

       Task DeleteAsync(Guid id);

       Task Update(T entity);
    }
}
