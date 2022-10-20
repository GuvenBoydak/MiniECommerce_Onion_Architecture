namespace MiniECommerce.Domain
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        //Relational Properyties
        public List<Product> Products { get; set; }
    }

}
