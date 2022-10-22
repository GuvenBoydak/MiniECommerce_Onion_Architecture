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

        public Guid AppUserID { get; set; }

        public Guid ProductID { get; set; }

        //Relational Properties
        public virtual Product Product { get; set; }

        public virtual AppUser AppUser { get; set; }
    }

}
