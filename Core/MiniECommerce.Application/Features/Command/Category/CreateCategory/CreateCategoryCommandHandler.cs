using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class CreateCategoryCommandHandler : AsyncRequestHandler<CreateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<CreateCategoryCommand, Category>(request);

            await _categoryService.AddAsync(category);

            await _unitOfWork.SaveAsync();
        }
    }
}
