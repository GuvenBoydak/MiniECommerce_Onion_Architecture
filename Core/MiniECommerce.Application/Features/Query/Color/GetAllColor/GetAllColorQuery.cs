using MediatR;

namespace MiniECommerce.Application
{
    public class GetAllColorQuery:IRequest<List<ColorListDto>>
    {
    }
}
