namespace MiniECommerce.Application
{
    public interface IUnitOfWork
    {
        Task SaveAsync();
    }
}
