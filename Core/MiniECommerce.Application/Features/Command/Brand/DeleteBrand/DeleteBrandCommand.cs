using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteBrandCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
