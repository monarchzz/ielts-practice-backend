using System.Linq.Expressions;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class ManagerRepository : BaseRepository, IManagerRepository
{
    private readonly DbSet<Manager> _managers;

    private readonly IQueryable<Manager> _managersQueryable;

    public ManagerRepository(AppDbContext context) :
        base(context)
    {
        _managers = Context.Managers;
        _managersQueryable = _managers.AsNoTracking();
    }

    public Task<bool> ExistsAsync(Expression<Func<Manager, bool>> predicate)
    {
        return _managersQueryable.AnyAsync(predicate);
    }

    public Task<Manager?> GetByIdAsync(Guid id)
    {
        return _managersQueryable
            .Include(x => x.Avatar)
            .SingleOrDefaultAsync(manager => manager.Id == id);
    }

    public Task<Manager?> GetByEmailAsync(string email)
    {
        return _managersQueryable
            .Include(x => x.Avatar)
            .SingleOrDefaultAsync(manager => manager.Email == email);
    }

    public Task<List<Manager>> GetAllAsync()
    {
        return _managersQueryable.ToListAsync();
    }

    public async Task AddAsync(Manager manager)
    {
        await _managers.AddAsync(manager);
    }

    public void Update(Manager manager)
    {
        _managers.Update(manager);
    }

    public void Remove(Manager manager)
    {
        _managers.Remove(manager);
    }
}