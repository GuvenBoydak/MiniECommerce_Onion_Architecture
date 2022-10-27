using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteAppUserCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
