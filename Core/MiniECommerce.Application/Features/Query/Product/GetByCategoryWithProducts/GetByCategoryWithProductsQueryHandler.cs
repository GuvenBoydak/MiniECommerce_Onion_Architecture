using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByCategoryWithProductsQueryHandler : IRequestHandler<GetByCategoryWithProductsQuery, List<ProductListDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetByCategoryWithProductsQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetByCategoryWithProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productService.GetByCategoryWithProductsAsync(request.CategoryID);

            List<ProductListDto> productListDtos = _mapper.Map<List<Product>, List<ProductListDto>>(products);

            return productListDtos;
        }
    }
}
