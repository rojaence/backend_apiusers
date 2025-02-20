namespace apiUsers.Models;

public class User
{
    public int UserId { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public bool Status { get; set; }
    public int Age { get; set; }
    public DateOnly BirthDate { get; set; }
    public required string Address { get; set; }

    public int ProfileId { get; set; } 
    public Profile Profile { get; set; }
    public int PositionId { get; set; }
    public Position Position { get; set; }
}