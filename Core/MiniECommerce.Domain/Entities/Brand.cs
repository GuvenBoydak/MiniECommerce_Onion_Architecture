﻿namespace MiniECommerce.Domain
{

    public class Brand : BaseEntity
    {
        public string Name { get; set; }

        //Relational Properties
        public virtual List<Product> Products { get; set; }
    }
}
