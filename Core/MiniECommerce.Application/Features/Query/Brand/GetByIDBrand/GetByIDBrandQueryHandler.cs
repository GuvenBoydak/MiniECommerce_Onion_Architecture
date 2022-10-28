using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDBrandQueryHandler : IRequestHandler<GetByIDBrandQuery, BrandDto>
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public GetByIDBrandQueryHandler(IMapper mapper, IBrandService brandService)
        {
            _mapper = mapper;
            _brandService = brandService;
        }
        public async Task<BrandDto> Handle(GetByIDBrandQuery request, CancellationToken cancellationToken)
        {
           Brand brand = await _brandService.GetByIDAsync(request.ID);

            BrandDto brandListDto = _mapper.Map<Brand, BrandDto>(brand);

            return brandListDto;
        }
    }
}
