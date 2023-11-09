using JuniperJunctionDistillery.Models;
namespace JuniperJunctionDistillery.Controllers
{
    public class items
    {
        private Stock stock = new Stock();
        public Stock Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        private string quantity;

        private string Quantity
        {
            get => quantity;
            set { quantity = value; }
        }

        public items()
        {

        }

        public items(Stock stock)
        {
            this.stock = stock;
            this.quantity = stock.Quantity;
        }
    }
}