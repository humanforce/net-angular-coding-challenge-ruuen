using Domain.Entities;

namespace Infrastructure.Repositories;

public interface ITicketRepository
{
    public List<Ticket> GetAllBySprint(int sprintId);
}