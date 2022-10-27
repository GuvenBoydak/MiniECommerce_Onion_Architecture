using MediatR;

namespace MiniECommerce.Application
{
    public class UpdateAppUserCommand:IRequest
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }

        public string Email { get; set; }

        public bool Active { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime LastActivty { get; set; }

        public string PhoneNumber { get; set; }
    }
}
