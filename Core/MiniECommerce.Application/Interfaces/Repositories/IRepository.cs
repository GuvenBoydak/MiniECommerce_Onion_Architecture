using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IRepository<T> where  T :BaseEntity
    {
        public DbSet<T> Table { get; }
    }
}
