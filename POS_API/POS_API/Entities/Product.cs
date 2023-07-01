using System.Net.Quic;
using System.Text.Json.Serialization;

namespace POS_API.Entities
{
    public class Product:NoteBaseModel
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        [JsonIgnore]
        public double TotalAmount { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public Product()
        {
            this.TotalAmount = Price * Quantity;
        }
    }
}
