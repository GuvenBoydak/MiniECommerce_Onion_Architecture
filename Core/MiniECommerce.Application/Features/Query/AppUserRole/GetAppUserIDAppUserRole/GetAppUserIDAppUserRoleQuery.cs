using MediatR;

namespace MiniECommerce.Application
{
    public class GetAppUserIDAppUserRoleQuery:IRequest<List<AppUserRoleListDto>>
    {
        public Guid AppUserID { get; set; }
    }
}
