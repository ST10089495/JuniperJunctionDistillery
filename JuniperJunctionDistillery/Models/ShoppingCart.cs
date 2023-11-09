using System.ComponentModel.DataAnnotations;

namespace JuniperJunctionDistillery.Models
{
    public class ShoppingCart
    {
        public ICollection<CartDetails> Items { get; set; }
        public string Category { get; set; }

        [Required]
        public string UserId { get; set; }
        public bool isDeleted { get; set; } = false;
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public int Total { get; set; }
        public ShoppingCart()
        {
            Items = new List<CartDetails>();
        }
    }
}