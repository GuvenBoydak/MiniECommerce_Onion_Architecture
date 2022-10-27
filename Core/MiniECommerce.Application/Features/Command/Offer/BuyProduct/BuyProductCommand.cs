using MediatR;

namespace MiniECommerce.Application
{
    public class BuyProductCommand:IRequest
    {
        public Guid AppUserID { get; set; }

        public Guid ProductID { get; set; }
    }
}
