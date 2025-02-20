using System.Text.Json.Serialization;

namespace apiUsers.Models;

public class Profile
{
    public int ProfileId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    [JsonIgnore]
    public ICollection<User> Users { get; set; } = new List<User>();
}