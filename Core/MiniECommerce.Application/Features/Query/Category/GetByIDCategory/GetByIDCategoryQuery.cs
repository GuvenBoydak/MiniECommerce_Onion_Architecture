using MediatR;

namespace MiniECommerce.Application
{
    public class GetByIDCategoryQuery:IRequest<CategoryDto>
    {
        public Guid ID { get; set; }
    }
}
