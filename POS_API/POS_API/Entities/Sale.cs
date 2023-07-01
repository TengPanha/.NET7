namespace POS_API.Entities
{
    public class Sale:BaseModel
    {
        public DateTime SaleDate { get; set; }
        public int CustomerID { get; set; }
        public double TotalAmount { get; set; }
    }
}
