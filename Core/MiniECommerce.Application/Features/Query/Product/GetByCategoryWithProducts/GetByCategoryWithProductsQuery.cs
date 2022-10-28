using MediatR;

namespace MiniECommerce.Application
{
    public class GetByCategoryWithProductsQuery:IRequest<List<ProductListDto>>
    {
        public Guid CategoryID { get; set; }
    }
}
