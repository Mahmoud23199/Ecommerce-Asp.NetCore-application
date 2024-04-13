using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Models
{
    public class ActorMovies
    {
        public int Id { get; set; }

        [ForeignKey("Actor")]
        public int ActorId { get; set; }
        public virtual Actor Actor { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
    }
}
