namespace POS_API.Entities
{
    public class Permission:BaseModel
    {
        public string? Name { get; set; }
        public ICollection<RolePermission> RolePermissions{get; set;}

    }
}
