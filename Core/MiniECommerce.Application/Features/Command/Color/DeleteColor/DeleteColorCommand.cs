using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteColorCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
