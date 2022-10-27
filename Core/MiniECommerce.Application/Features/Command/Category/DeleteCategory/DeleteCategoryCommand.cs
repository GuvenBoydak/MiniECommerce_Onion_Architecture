using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteCategoryCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
