using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDProductQuery:IRequest<ProductDto>
    {
        public Guid ID { get; set; }
    }
}
