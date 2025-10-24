namespace ProductApp.Models
{
    public class ProductDTO
    {
        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int StockQuantity { get; set; }

        public int CategoryId { get; set; }
    }
}
