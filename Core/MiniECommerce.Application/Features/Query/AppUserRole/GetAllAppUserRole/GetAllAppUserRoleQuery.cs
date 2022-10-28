using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllAppUserRoleQuery:IRequest<List<AppUserRoleListDto>>
    {
    }
}
