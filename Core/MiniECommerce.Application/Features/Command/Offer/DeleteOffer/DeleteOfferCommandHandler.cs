using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteOfferCommandHandler : AsyncRequestHandler<DeleteOfferCommand>
    {
        private readonly IOfferService _offerService;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteOfferCommandHandler(IOfferService offerService, IUnitOfWork unitOfWork)
        {
            _offerService = offerService;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(DeleteOfferCommand request, CancellationToken cancellationToken)
        {
            await _offerService.DeleteAsync(request.ID);

            await _unitOfWork.SaveAsync();
        }
    }
}
