using MediatR;

namespace MiniECommerce.Application
{
    public class CreateColorCommand : IRequest
    {
        public string Name { get; set; }
    }
}

