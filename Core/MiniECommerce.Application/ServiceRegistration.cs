using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace MiniECommerce.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection collection)
        {
            collection.AddMediatR(typeof(ServiceRegistration)); 
        }
    }
}
