using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IManagerRepository : IBaseRepository
{
    Task<bool> ExistsAsync(Expression<Func<Manager, bool>> predicate);

    Task<Manager?> GetByIdAsync(Guid id);

    Task<Manager?> GetByEmailAsync(string email);

    Task<List<Manager>> GetAllAsync();

    Task AddAsync(Manager manager);

    void Update(Manager manager);

    void Remove(Manager manager);
}