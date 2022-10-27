using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateColorCommandHandler : AsyncRequestHandler<UpdateColorCommand>
    {
        private readonly IColorService _colorService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateColorCommandHandler(IColorService colorService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _colorService = colorService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdateColorCommand request, CancellationToken cancellationToken)
        {
            Color color = _mapper.Map<UpdateColorCommand, Color>(request);

            await _colorService.UpdateAsync(color);

            await _unitOfWork.SaveAsync();
        }
    }

}
