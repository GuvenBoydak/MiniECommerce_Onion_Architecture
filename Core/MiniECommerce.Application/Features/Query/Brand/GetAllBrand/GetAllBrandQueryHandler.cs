using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllBrandQueryHandler : IRequestHandler<GetAllBrandQuery, List<BrandListDto>>
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public GetAllBrandQueryHandler(IMapper mapper, IBrandService brandService)
        {
            _mapper = mapper;
            _brandService = brandService;
        }
        public async Task<List<BrandListDto>> Handle(GetAllBrandQuery request, CancellationToken cancellationToken)
        {
            List<Brand> brands = await _brandService.GetAll();

            List<BrandListDto> brandListDtos = _mapper.Map<List<Brand>, List<BrandListDto>>(brands);

            return brandListDtos;
        }
    }
}
