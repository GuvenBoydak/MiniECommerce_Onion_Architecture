using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IWriteRepository<T> :IRepository<T> where T : BaseEntity
    {
       Task<bool> AddAsync(T entity);

       Task<bool> DeleteAsync(Guid id);

       Task<bool> Update(T entity);
    }
}
