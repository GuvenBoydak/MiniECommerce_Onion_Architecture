using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Application
{
    public interface IBaseService<T> where T :BaseEntity
    {
        Task<IQueryable<T>> GetActiveAsync();

        Task<IQueryable<T>> GetPassiveAsync();

        Task<IQueryable<T>> GetAll();

        Task<IQueryable<T>> Where(Expression<Func<T, bool>> filter);

        Task<T> GetByIDAsync(Guid ID);

        Task<bool> AddAsync(T entity);

        Task<bool> DeleteAsync(Guid id);

        Task<bool> Update(T entity);
    }
}
