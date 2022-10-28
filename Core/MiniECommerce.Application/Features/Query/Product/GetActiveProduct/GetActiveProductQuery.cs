using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveProductQuery:IRequest<List<ProductListDto>>
    {
    }
}
