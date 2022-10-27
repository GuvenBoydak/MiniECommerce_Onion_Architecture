using MediatR;

namespace MiniECommerce.Application
{
    public class OfferApprovalCommand:IRequest
    {
        public int ID { get; set; }

        public bool IsApproved { get; set; }

        public Guid AppUserID { get; set; }

        public Guid ProductID { get; set; }
    }
}
