using MediatR;

namespace MiniECommerce.Application
{
    public class UpdateBrandCommand:IRequest
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
