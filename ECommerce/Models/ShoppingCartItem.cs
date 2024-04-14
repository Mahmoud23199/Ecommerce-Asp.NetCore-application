using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }

        public Movie Movie { get; set; }

        public int Amount { get; set; }

        public string ShoppingCardId { get; set; }//to delete card after make order complete 

    }
}
