using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Producer
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Profile Picture")]
        public string profilepictureURL { get; set; }
        [Required]
        [DisplayName("Name")]
        public string FullName { get; set; }
        [Required]
        public string Bio { get; set; }

        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();

    }
}
