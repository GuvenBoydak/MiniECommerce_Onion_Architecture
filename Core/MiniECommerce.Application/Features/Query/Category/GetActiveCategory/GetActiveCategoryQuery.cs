using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveCategoryQuery:IRequest<List<CategoryListDto>>
    {
    }
}
