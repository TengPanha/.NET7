namespace POS_API.Entities
{
    public class Supplier:NoteBaseModel
    {
        public string? CompanyName { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? SupplierDate { get; set; }
        public string? AttachmentLink { get; set; }
    }
}
