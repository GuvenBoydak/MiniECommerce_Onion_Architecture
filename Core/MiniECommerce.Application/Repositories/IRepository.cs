using Microsoft.EntityFrameworkCore;
using MiniECommerce.Domain;

namespace MiniECommerce.Application
{
    public interface IRepository<T> where  T :BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
