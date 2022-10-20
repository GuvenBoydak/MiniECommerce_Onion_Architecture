﻿namespace MiniECommerce.Domain
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

        public int CategoryID { get; set; }

        public int? BrandID { get; set; }

        public int? ColorID { get; set; }

        public int AppUserID { get; set; }

        //Relational Properties
        public Category Category { get; set; }

        public Brand Brand { get; set; }

        public Color Color { get; set; }

        public List<Offer> Offers { get; set; }

        public AppUser AppUser { get; set; }
    }

}
