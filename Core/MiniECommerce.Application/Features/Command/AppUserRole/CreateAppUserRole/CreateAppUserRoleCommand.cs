using MediatR;

namespace MiniECommerce.Application
{
    public class CreateAppUserRoleCommand:IRequest
    {
        public Guid AppUserID { get; set; }

        public Guid RoleID { get; set; }
    }
}
