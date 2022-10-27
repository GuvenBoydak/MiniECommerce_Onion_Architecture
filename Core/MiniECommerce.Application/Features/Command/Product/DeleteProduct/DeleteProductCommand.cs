using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteProductCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
