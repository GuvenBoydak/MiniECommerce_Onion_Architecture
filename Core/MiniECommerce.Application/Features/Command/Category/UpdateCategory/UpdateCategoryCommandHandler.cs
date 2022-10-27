using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class UpdateCategoryCommandHandler : AsyncRequestHandler<UpdateCategoryCommand>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateCategoryCommandHandler(ICategoryService categoryService, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        protected override async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            Category category = _mapper.Map<UpdateCategoryCommand, Category>(request);

            await _categoryService.UpdateAsync(category);

            await _unitOfWork.SaveAsync();
        }
    }
}
