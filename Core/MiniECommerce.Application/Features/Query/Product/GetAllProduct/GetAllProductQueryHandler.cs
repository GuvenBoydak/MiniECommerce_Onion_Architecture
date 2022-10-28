using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, List<ProductListDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAllProductQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAllProductQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productService.GetAll();

            List<ProductListDto> productListDtos = _mapper.Map<List<Product>, List<ProductListDto>>(products);

            return productListDtos;
        }
    }
}
