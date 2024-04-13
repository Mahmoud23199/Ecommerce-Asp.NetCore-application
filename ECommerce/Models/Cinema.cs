using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Cinema
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Logo { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public virtual ICollection<Movie>Movies { get; set; } =new List<Movie>();


    }
}
