using MediatR;

namespace MiniECommerce.Application
{
    public class GetActiveColorQuery:IRequest<List<ColorListDto>>
    {
    }
}
