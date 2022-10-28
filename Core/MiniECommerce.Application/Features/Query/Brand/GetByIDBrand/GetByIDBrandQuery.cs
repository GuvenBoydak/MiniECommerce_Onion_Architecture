using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDBrandQuery:IRequest<BrandDto>
    {
        public Guid ID { get; set; }
    }
}
