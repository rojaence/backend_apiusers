using System.Text.Json.Serialization;

namespace apiUsers.Models;

public class Position
{
    public int PositionId { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    [JsonIgnore]
    public ICollection<User> Users { get; set; } = new List<User>();
}