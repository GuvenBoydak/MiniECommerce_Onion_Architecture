using MiniECommerce.Domain;
using System.Linq.Expressions;

namespace MiniECommerce.Application
{
    public interface IBaseService<T> where T :BaseEntity
    {
        Task<CustomResponseDto<List<T>>> GetActiveAsync();

        Task<CustomResponseDto<List<T>>> GetPassiveAsync();

        Task<CustomResponseDto<List<T>>> GetAll();

        Task<CustomResponseDto<List<T>>> Where(Expression<Func<T, bool>> filter);

        Task<CustomResponseDto<T>> GetByIDAsync(Guid ID);

        Task<CustomResponseDto<NoContentDto>> AddAsync(T entity);

        Task<CustomResponseDto<NoContentDto>> DeleteAsync(Guid id);

        Task<CustomResponseDto<NoContentDto>> UpdateAsync(T entity);
    }
}
