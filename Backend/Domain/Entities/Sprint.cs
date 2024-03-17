namespace Domain.Entities;

public class Sprint
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}