namespace MiniECommerce.Domain
{
    public class Color : BaseEntity
    {
        public string Name { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }
    }

}
