using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllCategoryQuery : IRequest<List<CategoryListDto>>
    {
    }
}
