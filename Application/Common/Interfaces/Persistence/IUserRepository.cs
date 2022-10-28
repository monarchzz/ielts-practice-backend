using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository : IBaseRepository
{
    Task<bool> ExistsAsync(Guid id);

    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByEmail(string email);
    
    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);

    void Update(User user);

    void Remove(User user);
}