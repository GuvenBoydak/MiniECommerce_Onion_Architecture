using MediatR;

namespace MiniECommerce.Application
{
    public class GetAppUserProductsQuery:IRequest<List<ProductListDto>>
    {
        public Guid AppUserID { get; set; }
    }
}
