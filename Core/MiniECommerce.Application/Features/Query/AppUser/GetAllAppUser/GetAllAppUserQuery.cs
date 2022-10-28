using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllAppUserQuery:IRequest<List<AppUserListDto>>
    {
    }
}
