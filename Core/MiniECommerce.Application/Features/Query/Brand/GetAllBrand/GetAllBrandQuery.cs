using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllBrandQuery:IRequest<List<BrandListDto>>
    {
    }
}
