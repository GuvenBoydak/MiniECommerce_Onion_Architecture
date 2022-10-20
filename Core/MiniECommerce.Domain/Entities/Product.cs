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
        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public Color Color { get; set; }

        public List<Offer> Offers { get; set; }

        public AppUser AppUser { get; set; }
    }

}
