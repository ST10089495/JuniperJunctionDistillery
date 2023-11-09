using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuniperJunctionDistillery.Models
{
    [Table("CartDetail")]
    public class CartDetails
    {
        public string Id { get; set; }
        [Required]
        public string ShoppingCart_Id { get; set; }
        [Required]
        public string StockId { get; set; }
        public string Quantity { get; set; }
        public Stock Stock { get; set; }
        public ShoppingCart ShoppingCart { get; set; }
    }
}