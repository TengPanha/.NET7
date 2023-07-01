namespace POS_API.Entities;

using System.Text.Json.Serialization;

public class User:BaseModel
{ 
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}