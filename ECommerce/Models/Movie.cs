using ECommerce.data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set;}
        
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set;}

        public double Price { get; set; }
        public MovieCategory MovieCategory { get; set;}

        [ForeignKey("Cinema")]
        public int CinemaId { get; set; }
        public virtual Cinema? Cinema { get; set; }

        [ForeignKey("Producer")]
        public int ProducerId { get; set; }
        public virtual Producer? Producer { get; set; }

        public virtual ICollection<ActorMovies> Actors { get; set; } = new List<ActorMovies>();

    }
}
