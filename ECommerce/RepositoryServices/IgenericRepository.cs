using ECommerce.Models;
using System.Linq.Expressions;

namespace ECommerce.RepositoryServices
{
    public interface IgenericRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<T> GetByIdAsyncWInclud(Expression<Func<T,bool>>match, string[] includs);
        Task<IEnumerable<T>> GetAllAsync(string[] includeRelated);
        Task AddAsync(T item);
        Task AddAsyncActorsWithMovie(int movieId, int[]actorsId);
        Task UpdateAsyncActorsWithMovie(int moveId, int[] actorsId);
        Task UpdateAsync(int id, T item);
        Task DeleteByIdAsync(int id);
        Task<IEnumerable<T>> FilterByName(string name, string[] includs, Expression<Func<T, bool>> match);
        Task<IEnumerable<T>> GetAllAsyncActorsWithMovie(Expression<Func<T,bool>>match,string[] includeRelated);

    }
}
