using System.ComponentModel.DataAnnotations;

namespace JuniperJunctionDistillery.Models
{
    public class Order
    {
        public string Id { get; set; }
        [Required]
        public string UserId { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        [Required]
        public string OrderStatusId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public OrderStatus OrderStatus { get; set; }
        public List<OrderDetails> OrderDetails { get; set; }
    }
}