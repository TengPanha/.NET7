using POS_API.Models.Categories;
using POS_API.Models.Suppliers;

namespace POS_API.Models.Products
{
    public class ProductReponse
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double TotalAmount { get; set; }
        public CategoryRequest Category { get; set; }
        public SupplierRequest Supplier { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }
    }
}
