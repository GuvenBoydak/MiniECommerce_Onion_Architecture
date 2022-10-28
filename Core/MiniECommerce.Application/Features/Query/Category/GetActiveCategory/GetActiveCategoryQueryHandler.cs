using AutoMapper;
using MediatR;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class GetActiveCategoryQueryHandler : IRequestHandler<GetActiveCategoryQuery, List<CategoryListDto>>
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public GetActiveCategoryQueryHandler(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        public async Task<List<CategoryListDto>> Handle(GetActiveCategoryQuery request, CancellationToken cancellationToken)
        {
            List<Category> categories = await _categoryService.GetActiveAsync();

            List<CategoryListDto> categoryListDtos = _mapper.Map<List<Category>, List<CategoryListDto>>(categories);

            return categoryListDtos;
        }
    }
}
