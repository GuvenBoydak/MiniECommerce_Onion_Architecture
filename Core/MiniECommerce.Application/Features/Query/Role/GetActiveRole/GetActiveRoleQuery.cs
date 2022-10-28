using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveRoleQuery:IRequest<List<RoleListDto>>
    {
    }
}
