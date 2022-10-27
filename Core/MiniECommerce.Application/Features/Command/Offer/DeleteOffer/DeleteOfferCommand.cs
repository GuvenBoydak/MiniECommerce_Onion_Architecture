using MediatR;

namespace MiniECommerce.Application
{
    public class DeleteOfferCommand:IRequest
    {
        public Guid ID { get; set; }
    }
}
