using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteBrandCommandHandler : AsyncRequestHandler<DeleteBrandCommand>
    {
        private readonly IBrandService _brandService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteBrandCommandHandler(IBrandService brandService, IUnitOfWork unitOfWork)
        {
            _brandService = brandService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteBrandCommand request, CancellationToken cancellationToken)
        {
            await _brandService.DeleteAsync(request.ID);

            await _unitOfWork.SaveAsync();
        }
    }
}
