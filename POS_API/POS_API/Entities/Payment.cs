namespace POS_API.Entities
{
    public class Payment:NoteBaseModel
    {
        public string PaymentType { get; set; }
        public double Amount { get; set; }
        public int SaleID { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
