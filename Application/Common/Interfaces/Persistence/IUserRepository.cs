using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository : IBaseRepository
{
    Task<User?> GetUserByIdAsync(Guid id);

    Task<User?> GetUserByEmail(string email);

    Task AddAsync(User user);
}