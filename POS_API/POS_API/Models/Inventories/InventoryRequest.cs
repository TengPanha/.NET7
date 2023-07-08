namespace POS_API.Models.Inventories
{
    public class InventoryRequest
    {
        public int StockQuantity { get; set; }
        public bool IsActive { get; set; }
    }
}
