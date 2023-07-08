namespace POS_API.Models.Suppliers
{
    public class SupplierRequest
    {
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? SupplierDate { get; set; }
        public string? AttachmentLink { get; set; }
        public string? Note { get; set; }
        public bool IsActive { get; set; }  =true;
    }
}
