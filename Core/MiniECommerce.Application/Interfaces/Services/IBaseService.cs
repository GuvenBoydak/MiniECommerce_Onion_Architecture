using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Application
{
    public interface IBaseService<T> where T :BaseEntity
    {
        Task<List<T>> GetActiveAsync();

        Task<List<T>> GetPassiveAsync();

        Task<List<T>> GetAll();

        Task<List<T>> Where(Expression<Func<T, bool>> filter);

        Task<T> GetByIDAsync(Guid ID);

        Task AddAsync(T entity);

        Task DeleteAsync(Guid id);

        Task UpdateAsync(T entity);
    }
}
