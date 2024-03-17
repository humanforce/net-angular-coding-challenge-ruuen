namespace Domain.Entities;

public class SprintCapacity
{
    public required double TotalPointsCommitted { get; set; }
    public required double TotalPointsCompleted { get; set; }
    public required double CapacityPercent { get; set; }
}