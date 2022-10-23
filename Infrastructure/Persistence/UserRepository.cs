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

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _userQueryable.SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _userQueryable.SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }
}