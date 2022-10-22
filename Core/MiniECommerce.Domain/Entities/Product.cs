namespace MiniECommerce.Domain
{
    public class Product : BaseEntity
    {
        public Product()
        {
            IsOfferable = true;
            IsSold = false;
        }

        public string Name { get; set; }

        public decimal UnitPrice { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public bool IsOfferable { get; set; }

        public bool IsSold { get; set; }

        public UsageStatus UsageStatus { get; set; }

        public Guid CategoryID { get; set; }

        public Guid? BrandID { get; set; }

        public Guid? ColorID { get; set; }

        public Guid AppUserID { get; set; }

        //Relational Properties
        public virtual Category Category { get; set; }

        public virtual Brand Brand { get; set; }
         
        public virtual Color Color { get; set; }

        public virtual List<Offer> Offers { get; set; }

        public virtual AppUser AppUser { get; set; }
    }

}
