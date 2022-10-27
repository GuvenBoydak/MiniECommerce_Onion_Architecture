using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateColorCommandHandler : AsyncRequestHandler<CreateColorCommand>
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateColorCommandHandler(IColorService colorService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _colorService = colorService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateColorCommand request, CancellationToken cancellationToken)
        {
            Color color = _mapper.Map<CreateColorCommand, Color>(request);

            await _colorService.AddAsync(color);

            await _unitOfWork.SaveAsync();
        }
    }
}

