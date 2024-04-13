using ECommerce.Models;
using ECommerce.RepositoryServices;

namespace ECommerce.UnitOfWork
{
    public interface IUnitOfWork:IDisposable
    {
        IgenericRepository<Actor> Actors { get; }
        IgenericRepository<Cinema> Cinemas { get; }
        IgenericRepository<Movie> Movies { get; }
        IgenericRepository<Producer> Producers { get; }
        IgenericRepository<ActorMovies> ActorMoviess { get; }


        int Complete();
    }
}
