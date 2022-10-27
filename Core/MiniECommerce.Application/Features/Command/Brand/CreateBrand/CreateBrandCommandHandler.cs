using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateBrandCommandHandler : AsyncRequestHandler<CreateBrandCommand>
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateBrandCommandHandler(IBrandService brandService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _brandService = brandService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            Brand brand = _mapper.Map<CreateBrandCommand, Brand>(request);

            await _brandService.AddAsync(brand);
            await _unitOfWork.SaveAsync();
        }
    }

}
