using MediatR;

namespace MiniECommerce.Application
{
    public class UpdatePasswordAppUserCommand:IRequest
    {
        public Guid ID { get; set; }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }

        public string ConfirmPassword { get; set; }
    }
}
