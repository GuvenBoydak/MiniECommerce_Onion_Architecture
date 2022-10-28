using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetAllColorQueryHandler : IRequestHandler<GetAllColorQuery, List<ColorListDto>>
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public GetAllColorQueryHandler(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        public async Task<List<ColorListDto>> Handle(GetAllColorQuery request, CancellationToken cancellationToken)
        {
            List<Color> colors = await _colorService.GetAll();

            List<ColorListDto> colorListDtos = _mapper.Map<List<Color>, List<ColorListDto>>(colors);

            return colorListDtos;
        }
    }
}
