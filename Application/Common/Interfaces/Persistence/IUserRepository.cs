using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IUserRepository : IBaseRepository
{
    Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate);

    Task<User?> GetByIdAsync(Guid id);

    Task<User?> GetByEmailAsync(string email);

    Task<List<User>> GetAllAsync();

    Task AddAsync(User user);

    void Update(User user);

    void Remove(User user);
}