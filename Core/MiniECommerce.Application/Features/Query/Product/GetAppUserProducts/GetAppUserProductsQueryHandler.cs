using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAppUserProductsQueryHandler : IRequestHandler<GetAppUserProductsQuery, List<ProductListDto>>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public GetAppUserProductsQueryHandler(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        public async Task<List<ProductListDto>> Handle(GetAppUserProductsQuery request, CancellationToken cancellationToken)
        {
            List<Product> products = await _productService.GetAppUserProductsAsync(request.AppUserID);

            List<ProductListDto> productListDtos = _mapper.Map<List<Product>, List<ProductListDto>>(products);

            return productListDtos;
        }
    }
}
