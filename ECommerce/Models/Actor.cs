using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Profile Picture")]
        public string profilepictureURL { get; set; }
        [Required]
        [DisplayName("Full Name")]
        public string FullName { get; set; }

        [Required]
        [DisplayName("Biography")]
        public string Bio { get; set;}

        public virtual ICollection<ActorMovies> Actors { get; set; } = new List<ActorMovies>();
    }
}
