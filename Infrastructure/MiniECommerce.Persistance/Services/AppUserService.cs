using MiniECommerce.Application;
using MiniECommerce.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MiniECommerce.Persistance.Services
{
    public class AppUserService : IAppUserService
    {
        public Task<bool> AddAsync(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AppUser>> GetActiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AppUser>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetAppUserProductsAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByActivationCode(Guid code)
        {
            throw new NotImplementedException();
        }

        public Task<List<Offer>> GetByAppUserOffersAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Product>> GetByAppUserProductsOffers(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetByIDAsync(Guid ID)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AppUser>> GetPassiveAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Role>> GetRoles(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AppUser entity)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<AppUser>> Where(Expression<Func<AppUser, bool>> filter)
        {
            throw new NotImplementedException();
        }
    }
}
