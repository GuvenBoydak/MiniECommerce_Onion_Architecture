using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MiniECommerce.Application;
using MiniECommerce.Domain;
using MiniECommerce.Infrastructure;
using MiniECommerce.Persistance.Services;

namespace MiniECommerce.Persistance
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<MiniECommerceDbContext>(options => options.UseNpgsql(Configuration.ConnectionString));

           

            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
            services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();


            services.AddScoped<IReadAppUserRepository, AppUserReadRepository>();
            services.AddScoped<IWriteAppUserRepository, AppUserWriteRepository>();
            services.AddScoped<IReadAppUserRoleRepository, AppUserRoleReadRepository>();
            services.AddScoped<IWriteAppUserRoleRepository, AppUserRoleWriteRepositorty>();
            services.AddScoped<IReadRoleRepository, RoleReadRepository>();
            services.AddScoped<IWriteRoleRepository, RoleWriteRepository>();
            services.AddScoped<IReadBrandRepository, BrandReadRepository>();
            services.AddScoped<IWriteBrandRepository, BrandWriteRepository>();
            services.AddScoped<IReadCategoryRepository, CategoryReadRepository>();
            services.AddScoped<IWriteCategoryRepository, CategoryWriteRepository>();
            services.AddScoped<IReadColorRepository, ColorReadRepository>();
            services.AddScoped<IWriteColorRepository, ColorWriteRepository>();
            services.AddScoped<IReadOfferRepository, OfferReadRepository>();
            services.AddScoped<IWriteOfferRepository, OfferWriteRepository>();
            services.AddScoped<IReadProductRepository, ProductReadRepository>();
            services.AddScoped<IWriteProductRepository, ProductWriteRepository>();


            services.AddScoped<IAppUserService, AppUserService>();
            services.AddScoped<IAppUserRoleService, AppUserRoleService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ITokenHelper, TokenHelper>();



           
            return services;
        }
    }
}
