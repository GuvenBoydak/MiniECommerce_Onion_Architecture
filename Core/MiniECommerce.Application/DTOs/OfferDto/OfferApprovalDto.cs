namespace MiniECommerce.Application
{
    public class OfferApprovalDto
    {
        public Guid ID { get; set; }

        public bool IsApproved { get; set; }

        public Guid ProductID { get; set; }
    }
}
