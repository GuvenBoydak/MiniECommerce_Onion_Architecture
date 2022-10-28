using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveAppUserQuery:IRequest<List<AppUserListDto>>
    {
    }

}
