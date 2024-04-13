using ECommerce.Models;
using ECommerce.RepositoryServices;

namespace ECommerce.UnitOfWork
{
    public class UnitOfWorkClass : IUnitOfWork
    {
        private readonly EcommerceContext context;
   
        public IgenericRepository<Actor> Actors { get; private set; }

        public IgenericRepository<Cinema> Cinemas { get; private set; }

        public IgenericRepository<Movie> Movies { get; private set; }

        public IgenericRepository<Producer> Producers { get; private set; }

        public UnitOfWorkClass(EcommerceContext context)
        {
            this.context = context;
            Actors = new genericRepository<Actor>(context);
            Cinemas = new genericRepository<Cinema>(context);
            Movies = new genericRepository<Movie>(context);
            Producers = new genericRepository<Producer>(context);

        }

        public int Complete()
        {
           return context.SaveChanges();
        }

        public void Dispose()
        {
            context.Dispose();
        }
    }
}
