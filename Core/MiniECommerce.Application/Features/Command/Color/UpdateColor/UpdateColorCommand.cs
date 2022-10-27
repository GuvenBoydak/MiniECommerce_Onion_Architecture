using MediatR;

namespace MiniECommerce.Application
{
    public class UpdateColorCommand:IRequest
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
