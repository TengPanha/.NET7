namespace POS_API.Models.Categories
{
    public class CategoryRequest
    {
        public string Name { get; set; } = string.Empty;
        public string Note { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;
    }
}
