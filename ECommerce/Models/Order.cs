using System.ComponentModel.DataAnnotations;

namespace ECommerce.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        private const string EmailRegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        [Required,DataType(DataType.EmailAddress),RegularExpression(EmailRegexPattern, ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; } =new List<OrderItem>();

    }
}
