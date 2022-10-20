using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class UserRepository : BaseRepository, IUserRepository
{
    private readonly DbSet<User> _users;

    public UserRepository(AppDbContext context) : base(context)
    {
        _users = Context.Users;
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _users.AsNoTracking().SingleOrDefaultAsync(user => user.Id == id);
    }

    public async Task<User?> GetUserByEmail(string email)
    {
        return await _users.AsNoTracking().SingleOrDefaultAsync(user => user.Email == email);
    }

    public async Task AddAsync(User user)
    {
        await _users.AddAsync(user);
    }
}