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
        protected readonly IUnitOfWork _unitOfWork;

        public BaseService(IReadRepository<T> readRepository, IWriteRepository<T> writeRepository, IUnitOfWork unitOfWork)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddAsync(T entity)
        {
            await _writeRepository.AddAsync(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            await _writeRepository.DeleteAsync(id);
            await _unitOfWork.SaveAsync();
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
            await _writeRepository.Update(entity);
            await _unitOfWork.SaveAsync();
        }

        public async Task<List<T>> Where(Expression<Func<T, bool>> filter)
        {
            return await _readRepository.Where(filter).ToListAsync();
        }
    }
}
