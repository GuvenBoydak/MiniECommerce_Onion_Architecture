using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDColorQueryHandler : IRequestHandler<GetByIDColorQuery, ColorDto>
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;

        public GetByIDColorQueryHandler(IColorService colorService, IMapper mapper)
        {
            _colorService = colorService;
            _mapper = mapper;
        }

        public async Task<ColorDto> Handle(GetByIDColorQuery request, CancellationToken cancellationToken)
        {
            Color color = await _colorService.GetByIDAsync(request.ID);

            ColorDto colorDto = _mapper.Map<Color, ColorDto>(color);

            return colorDto;
        }
    }
}
