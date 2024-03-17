using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IPublicHolidayRepository
{
    public List<PublicHoliday> GetAllInDateRange(DateTime startDate, DateTime endDate);
}