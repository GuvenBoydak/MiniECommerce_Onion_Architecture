using MiniECommerce.Application;
using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Persistance
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IRepository<T> _repository;

        public Task<bool> AddAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIDAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> GetPassiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<T>> Where(Expression<Func<T, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
