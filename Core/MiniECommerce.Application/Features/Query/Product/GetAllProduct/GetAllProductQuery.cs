using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllProductQuery:IRequest<List<ProductListDto>>
    {
    }
}
