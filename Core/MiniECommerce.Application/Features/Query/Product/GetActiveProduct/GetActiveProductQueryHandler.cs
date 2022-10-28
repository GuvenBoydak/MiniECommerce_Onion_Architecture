using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveProductQueryHandler : IRequestHandler<GetActiveProductQuery, List<ProductListDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetActiveProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetActiveProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productService.GetActiveAsync();

            List<ProductListDto> productListDtos = _mapper.Map<List<Product>, List<ProductListDto>>(products);

            return productListDtos;
        }
    }
}
