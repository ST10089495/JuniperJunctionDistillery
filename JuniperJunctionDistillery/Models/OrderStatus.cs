using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace JuniperJunctionDistillery.Models
{
    [Table("OrderStatus")]
    public class OrderStatus
    {
        public string Id { get; set; }
        [Required]
        public string StatusId { get; set; }
        [Required]
        [MaxLength(20)]
        public string StatusName { get; set; }
    }
}