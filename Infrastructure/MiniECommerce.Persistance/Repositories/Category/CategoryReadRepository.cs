﻿using MiniECommerce.Application;
using MiniECommerce.Domain;

namespace MiniECommerce.Persistance
{
    public class CategoryReadRepository : ReadRepository<Category>, IReadCategoryRepository
    {
        public CategoryReadRepository(MiniECommerceDbContext db) : base(db)
        {
        }
    }
}
