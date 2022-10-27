using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class BuyProductCommandHandler : AsyncRequestHandler<BuyProductCommand>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public BuyProductCommandHandler(IOfferService offerService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _offerService = offerService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(BuyProductCommand request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<BuyProductCommand, Offer>(request);

            await _offerService.BuyProductAsync(offer);

            await _unitOfWork.SaveAsync();
        }
    }
}
