using MediatR;

namespace MiniECommerce.Application
{
    public class UpdateRoleCommand:IRequest
    {
        public Guid ID { get; set; }

        public string Name { get; set; }
    }
}
