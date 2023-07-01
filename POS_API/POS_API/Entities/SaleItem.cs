namespace POS_API.Entities
{
    public class SaleItem:BaseModel
    {
        public int SaleID { get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
