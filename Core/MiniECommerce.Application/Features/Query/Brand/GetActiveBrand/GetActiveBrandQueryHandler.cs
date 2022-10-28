using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveBrandQueryHandler : IRequestHandler<GetActiveBrandQuery, List<BrandListDto>>
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public GetActiveBrandQueryHandler(IMapper mapper, IBrandService brandService)
        {
            _mapper = mapper;
            _brandService = brandService;
        }
        public async Task<List<BrandListDto>> Handle(GetActiveBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandService.GetActiveAsync();

            List<BrandListDto> brandListDtos = _mapper.Map<List<Brand>, List<BrandListDto>>(brands);

            return brandListDtos;
        }
    }
}
