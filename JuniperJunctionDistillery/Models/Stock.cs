namespace JuniperJunctionDistillery.Models
{
    public class Stock
    {
        public string Arrival { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public List<OrderDetails> OrderDetail { get; set; }
        public List<CartDetails> CartDetails { get; set; }
    }
}