
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

        public async Task AddAsyncActorsWithMovie(int movieId, int[] actorsId)
        {
            for (int i = 0; i < actorsId.Length; i++)
            {
                var actor = new ActorMovies { ActorId = actorsId[i],MovieId=movieId };

                await context.ActorMovies.AddAsync(actor);
            }
           await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsyncActorsWithMovie(Expression<Func<T, bool>> match, string[] includeRelated)
        {
            IQueryable<T> query= context.Set<T>();
            if(includeRelated != null) 
            {
                foreach (var iclude in includeRelated)
                {
                    query = query.Include(iclude);
                }
            }
            return await query.Where(match).ToListAsync();
        }

        public async Task UpdateAsyncActorsWithMovie(int movieId, int[] actorIds)
        {
            // Fetch all existing actor-movie associations for the given movieId
            var existingAssociations = await context.ActorMovies
                .Where(am => am.MovieId == movieId)
                .ToListAsync();

            // Iterate over the existing associations
            foreach (var association in existingAssociations.ToList())
            {
                // Check if the association's actorId is not present in the provided actorIds array
                if (!actorIds.Contains(association.ActorId))
                {
                    // If not present, remove the association from the context
                    context.ActorMovies.Remove(association);
                }
            }

            // Iterate over the provided actorIds
            foreach (var actorId in actorIds)
            {
                // Check if an association already exists for this actorId and movieId
                if (!existingAssociations.Any(am => am.ActorId == actorId))
                {
                    // If no association exists, create a new one
                    var newAssociation = new ActorMovies
                    {
                        MovieId = movieId,
                        ActorId = actorId
                    };

                    // Add the new association to the context
                    context.ActorMovies.Add(newAssociation);
                }
            }

            // Save changes to persist the updates
            await context.SaveChangesAsync();
        }


    }
}
