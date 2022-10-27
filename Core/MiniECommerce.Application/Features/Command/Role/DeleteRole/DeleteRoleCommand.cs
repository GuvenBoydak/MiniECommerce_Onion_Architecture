using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteRoleCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
