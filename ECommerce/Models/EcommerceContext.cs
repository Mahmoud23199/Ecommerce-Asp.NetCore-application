using Microsoft.EntityFrameworkCore;

namespace ECommerce.Models
{
    public class EcommerceContext:DbContext
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ActorMovies>ActorMovies  { get; set; }

        public EcommerceContext(DbContextOptions<EcommerceContext> options)
          : base(options)
        {
        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    //optionsBuilder.UseSqlServer("Server=DESKTOP-FH5NNMR;Database=Ecommerce;Encrypt=false;Trusted_Connection=True;TrustServerCertificate=True");
        //    base.OnConfiguring(optionsBuilder);
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            base.OnModelCreating(modelBuilder);
        }
    }
}
