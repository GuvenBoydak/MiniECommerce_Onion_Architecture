using MediatR;

namespace MiniECommerce.Application
{
    public class UpdateAppUserRoleCommand:IRequest
    {
        public Guid ID { get; set; }

        public Guid AppUserID { get; set; }

        public Guid RoleID { get; set; }
    }
}
