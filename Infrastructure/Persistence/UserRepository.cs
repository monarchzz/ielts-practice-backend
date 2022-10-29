using System.Linq.Expressions;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly DbSet<User> _users;

    private readonly IQueryable<User> _userQueryable;

    public UserRepository(AppDbContext context) : base(context)
    {
        _users = Context.Users;
        _userQueryable = _users.AsNoTracking();
    }

    public Task<bool> ExistsAsync(Expression<Func<User, bool>> predicate)
    {
        return _userQueryable.AnyAsync(predicate);
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        return _userQueryable.Include(x => x.Avatar).SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _userQueryable.Include(x => x.Avatar).SingleOrDefaultAsync(user => user.Email == email);
    }

    public Task<List<User>> GetAllAsync()
    {
        return _userQueryable.ToListAsync();
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }

    public void Update(User user)
    {
        _users.Update(user);
    }

    public void Remove(User user)
    {
        _users.Remove(user);
    }
}