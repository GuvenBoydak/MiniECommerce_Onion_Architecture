using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class OfferApprovalCommandHanler : AsyncRequestHandler<OfferApprovalCommand>
    {
        private readonly IOfferService _offerService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public OfferApprovalCommandHanler(IOfferService offerService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _offerService = offerService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(OfferApprovalCommand request, CancellationToken cancellationToken)
        {
            Offer offer = _mapper.Map<OfferApprovalCommand, Offer>(request);

            await _offerService.OfferApprovalAsync(offer);

            await _unitOfWork.SaveAsync();
        }
    }
}
