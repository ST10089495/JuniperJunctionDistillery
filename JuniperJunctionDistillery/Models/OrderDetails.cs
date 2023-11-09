using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuniperJunctionDistillery.Models
{
    [Table("OrderDetails")]
    public class OrderDetails
    {
        public string Id { get; set; }
        [Required]
        public string Order_Id { get; set; }
        [Required]
        public string StockId { get; set; }
        [Required]
        public string Quantity { get; set; }
        public double UnitPrice { get; set; }
        public Order Order { get; set; }
        public Stock Stock { get; set; }

    }
}