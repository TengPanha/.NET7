using System.Text.Json.Serialization;

namespace POS_API.Models.Products
{
    public class ProductRequest
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public double TotalAmount { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
    }
}
