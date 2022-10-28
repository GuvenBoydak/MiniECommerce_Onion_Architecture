using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllRoleQuery:IRequest<List<RoleListDto>>
    {
    }
}
