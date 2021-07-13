using Microsoft.EntityFrameworkCore;
using ShopOnlineAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShopOnlineAPI.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ShopOnlineDBContext context;

        public GenericRepository(ShopOnlineDBContext context)
        {
            this.context = context;
        }

        public async Task Add(T entity)
        {
            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await context.Set<T>().FindAsync(id);
        }

        public async Task AddRange(IEnumerable<T> entities)
        {
            await context.Set<T>().AddRangeAsync(entities);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await context.Set<T>().ToListAsync();
        }

        public async Task Remove(T entity)
        {
            context.Set<T>().Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task RemoveRange(IEnumerable<T> entities)
        {
            context.Set<T>().RemoveRange(entities);
            await context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            context.Set<T>().Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task UpdateRange(IEnumerable<T> entities)
        {
            context.Set<T>().UpdateRange(entities);
            await context.SaveChangesAsync();
        }
    }
}
