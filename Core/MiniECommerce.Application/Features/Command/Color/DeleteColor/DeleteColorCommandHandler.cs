using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteColorCommandHandler : AsyncRequestHandler<DeleteColorCommand>
    {
        private readonly IColorService _colorService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteColorCommandHandler(IColorService colorService, IUnitOfWork unitOfWork)
        {
            _colorService = colorService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteColorCommand request, CancellationToken cancellationToken)
        {
            await _colorService.DeleteAsync(request.ID);

            await _unitOfWork.SaveAsync();
        }
    }
}
