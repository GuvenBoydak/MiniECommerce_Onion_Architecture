using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteAppUserRoleCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
