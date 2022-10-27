using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateProductCommandHandler : AsyncRequestHandler<CreateProductCommand>
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateProductCommandHandler(IProductService productService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _productService = productService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            Product product = _mapper.Map<CreateProductCommand, Product>(request);

            await _productService.AddAsync(product);

            await _unitOfWork.SaveAsync();
        }
    }

}
