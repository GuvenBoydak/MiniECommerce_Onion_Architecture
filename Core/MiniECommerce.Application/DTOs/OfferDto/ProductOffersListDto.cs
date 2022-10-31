namespace MiniECommerce.Application
{
    public class ProductOffersListDto
    {
        public Guid ID { get; set; }

        public decimal Price { get; set; }

        public bool IsApproved { get; set; }

        public Guid AppUserID { get; set; }

        public Guid ProductID { get; set; }
    }
}
