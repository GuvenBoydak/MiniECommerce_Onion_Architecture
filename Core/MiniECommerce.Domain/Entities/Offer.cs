namespace MiniECommerce.Domain
{
    public class Offer : BaseEntity
    {
        public Offer()
        {
            IsApproved = false;
        }

        public decimal Price { get; set; }

        public bool IsApproved { get; set; }

        public int AppUserID { get; set; }

        public int ProductID { get; set; }

        //Relational Properties
        public Product Product { get; set; }

        public AppUser AppUser { get; set; }
    }

}
