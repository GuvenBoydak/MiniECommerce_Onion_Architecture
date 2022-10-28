using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDRoleQuery:IRequest<RoleDto>
    {
        public Guid ID { get; set; }
    }
}
