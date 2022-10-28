using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveBrandQuery:IRequest<List<BrandListDto>>
    {
    }
}
