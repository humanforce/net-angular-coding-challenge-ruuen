namespace Domain.Entities;

public class PublicHoliday
{
    public required string Name { get; set; }
    public required UserLocation Location { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}