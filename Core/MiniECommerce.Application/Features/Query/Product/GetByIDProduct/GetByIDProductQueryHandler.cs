using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDProductQueryHandler : IRequestHandler<GetByIDProductQuery, ProductDto>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetByIDProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        public async Task<ProductDto> Handle(GetByIDProductQuery request, CancellationToken cancellationToken)
        {
            Product product = await _productService.GetByIDAsync(request.ID);

            ProductDto productDto = _mapper.Map<Product, ProductDto>(product);

            return productDto;
        }
    }
}
