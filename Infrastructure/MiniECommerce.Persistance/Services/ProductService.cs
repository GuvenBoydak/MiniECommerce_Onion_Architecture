using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly IReadProductRepository _readProductRepository;
        public ProductService(IReadProductRepository readProductRepository, IWriteRepository<Product> writeRepository, IUnitOfWork unitOfWork) : base(readProductRepository, writeRepository)
        {
            _readProductRepository = readProductRepository;
        }

        public async Task<List<Product>> GetAppUserProductsAsync(Guid appUserID)
        {
            return await _readProductRepository.GetAppUserProductsAsync(appUserID);
        }

        public async Task<List<Product>> GetByCategoryWithProductsAsync(Guid categoryID)
        {
            return await _readProductRepository.GetByCategoryWithProductsAsync(categoryID);
        }

        public async Task<List<Product>> GetByOffersOfAppUserProductsAsync(Guid appUserID)
        {
            return await _readProductRepository.GetByOffersOfAppUserProductsAsync(appUserID);
        }
    }
}
