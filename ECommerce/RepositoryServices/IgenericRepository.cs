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
        Task UpdateAsync(int id, T item);
        Task DeleteByIdAsync(int id);
    }
}
