namespace Domain.Entities;

public class User
{
    public required string Name { get; set; }
    public required UserLocation Location { get; set; }
}

public class UserLocation
{
    public required string Country { get; set; }
}