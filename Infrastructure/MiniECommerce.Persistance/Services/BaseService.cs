using Microsoft.EntityFrameworkCore;
using MiniECommerce.Application;
using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Persistance
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        protected readonly IReadRepository<T> _readRepository;
        private readonly IWriteRepository<T> _writeRepository;

        public BaseService(IReadRepository<T> readRepository, IWriteRepository<T> writeRepository)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
        }

        public async Task AddAsync(T entity)
        {
            try
            {
                await _writeRepository.AddAsync(entity);
            }
            catch (Exception)
            {

                throw new ClientSideException($"Added Error {typeof(T)}");
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            try
            {
                await _writeRepository.DeleteAsync(id);
            }
            catch (Exception)
            {

                throw new ClientSideException($"Deleted Error {typeof(T)}");
            }
        }

        public async Task<List<T>> GetActiveAsync()
        {
            return await _readRepository.GetActive().ToListAsync();
        }

        public async Task<List<T>> GetAll()
        {
            return await _readRepository.GetAll().ToListAsync();
        }

        public async Task<T> GetByIDAsync(Guid id)
        {
            return await _readRepository.GetByIDAsync(id);
        }

        public async Task<List<T>> GetPassiveAsync()
        {
            return await _readRepository.GetPassive().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            try
            {
                await _writeRepository.Update(entity);
            }
            catch (Exception)
            {

                throw new ClientSideException($"Updated Error {typeof(T)}");
            }
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> filter)
        {
            return await _readRepository.Where(filter).ToListAsync();
        }
    }
}
