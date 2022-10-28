using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveAppUserRoleQuery:IRequest<List<AppUserRoleListDto>>
    {
    }
}
