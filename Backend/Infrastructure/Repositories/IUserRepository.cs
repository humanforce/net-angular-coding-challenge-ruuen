using Domain.Entities;

namespace Infrastructure.Repositories;

public interface IUserRepository
{
    public List<User> GetAll();
}