using Domain.Entities;

namespace Domain.Services;

public static class StatisticsService
{
    public static SprintCapacity CalculateSprintCapacity(IEnumerable<Ticket> sprintTicketData)
    {
        double totalCommitted = 0.0;
        double totalCompleted = 0.0;

        foreach (var ticket in sprintTicketData)
        {
            totalCommitted += ticket.Fields.StoryPoints;
            if (ticket.Fields.Status.Name == "Done")
            {
                totalCompleted += ticket.Fields.StoryPoints;
            }
        }

        double capacityPercent = (totalCompleted / totalCommitted) * 100;
        return new SprintCapacity
        {
            TotalPointsCommitted = totalCommitted,
            TotalPointsCompleted = totalCompleted,
            CapacityPercent = capacityPercent
        };
    }

    public static SprintVelocity CalculateSprintVelocity(SprintCapacity sprintCapacity)
    {
        var velocityCalc = (sprintCapacity.TotalPointsCompleted + sprintCapacity.TotalPointsCommitted) / 2;
        return new SprintVelocity
        {
            Value = velocityCalc
        };
    }
}