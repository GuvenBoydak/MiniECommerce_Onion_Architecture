using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveColorQueryHandler : IRequestHandler<GetActiveColorQuery, List<ColorListDto>>
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public GetActiveColorQueryHandler(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        public async Task<List<ColorListDto>> Handle(GetActiveColorQuery request, CancellationToken cancellationToken)
        {
            List<Color> colors = await _colorService.GetActiveAsync();

            List<ColorListDto> colorListDtos = _mapper.Map<List<Color>, List<ColorListDto>>(colors);

            return colorListDtos;
        }
    }
}
