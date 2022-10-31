using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public class ProductListDto 
    {
        public Guid ID { get; set; }

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
    }
}
