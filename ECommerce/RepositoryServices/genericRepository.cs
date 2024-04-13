
using ECommerce.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ECommerce.RepositoryServices
{
    public class genericRepository<T> : IgenericRepository<T> where T:class
    {
        private readonly EcommerceContext context;
        public genericRepository(EcommerceContext ecommerceContext)
        {
            this.context = ecommerceContext;
        }

        public async Task AddAsync(T item)
        {
           await context.Set<T>().AddAsync(item);
           await context.SaveChangesAsync();
        }
        public async Task<T> GetByIdAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                throw new Exception($"Entity of type {typeof(T)} with ID {id} not found.");
            }
            return entity;
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
            else
            {
                throw new Exception($"Entity of type {typeof(T)} with ID {id} not found.");
            }
        }

        public async Task<T> GetByIdAsyncWInclud(Expression<Func<T, bool>> match, string[] includs=null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includs != null)
            {
                foreach (var include in includs)
                {
                    query = query.Include(include);
                }
            }

            var result = await query.SingleOrDefaultAsync(match);
            return result;
        }




        public async Task<IEnumerable<T>> GetAllAsync(string[] includeRelated = null)
        {
            IQueryable<T> query = context.Set<T>();

            if (includeRelated != null)
            {
                foreach (var include in includeRelated) 
                {
                  query =query.Include(include);
                }
            }

            return await query.ToListAsync();
           
        }

        public async Task UpdateAsync(int id, T item)
        {
            var entity = await GetByIdAsync(id);
            if (entity != null)
            {
                context.Entry(entity).CurrentValues.SetValues(item);
               await context.SaveChangesAsync();

            }
        }
    }
}
