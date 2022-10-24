﻿using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class BrandWriteRepositry : WriteRepository<Brand>, IWriteBrandRepository
    {
        public BrandWriteRepositry(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
