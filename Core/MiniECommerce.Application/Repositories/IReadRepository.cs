using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Application
{
    public interface IReadRepository<T>:IRepository<T> where T: BaseEntity
    {
        IQueryable<T> GetActive();

        IQueryable<T> GetPassive();

        IQueryable<T> GetAll();

        IQueryable<T> Where(Expression<Func<T,bool>> filter);

        Task<T> GetByFirstAsync(Expression<Func<T, bool>> filter);

        Task<T> GetByIDAsync(Guid ID);
    }
}
