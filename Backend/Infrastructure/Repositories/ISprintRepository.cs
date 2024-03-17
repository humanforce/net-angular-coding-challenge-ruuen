using Domain.Entities;

namespace Infrastructure.Repositories;

public interface ISprintRepository
{
    public Sprint? GetById(int sprintId);
    public Sprint? GetByDates(DateTime startDate, DateTime endDate);
    public Sprint GetCurrentOrLast();
    public List<Sprint> GetPreviousSprintsById(int sprintId, int maxPrevCount);

}