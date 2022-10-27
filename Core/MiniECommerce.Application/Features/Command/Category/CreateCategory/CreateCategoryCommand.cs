using MediatR;

namespace MiniECommerce.Application
{
    public class CreateCategoryCommand:IRequest
    {
        public Guid ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
