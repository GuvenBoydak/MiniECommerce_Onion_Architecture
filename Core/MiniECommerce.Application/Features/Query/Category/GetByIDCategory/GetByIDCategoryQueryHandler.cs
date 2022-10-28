using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetByIDCategoryQueryHandler : IRequestHandler<GetByIDCategoryQuery, CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetByIDCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<CategoryDto> Handle(GetByIDCategoryQuery request, CancellationToken cancellationToken)
        {
            Category category = await _categoryService.GetByIDAsync(request.ID);

            CategoryDto categoryDto = _mapper.Map<Category, CategoryDto>(category);

            return categoryDto;
        }
    }
}
