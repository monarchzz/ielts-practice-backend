using Application.Common.Interfaces.Persistence;
using EFCore;

namespace Infrastructure.Persistence;

public abstract class BaseRepository : IBaseRepository
{
    protected readonly AppDbContext Context;

    protected BaseRepository(AppDbContext context)
    {
        Context = context;
    }

    public async Task SaveChangesAsync()
    {
        await Context.SaveChangesAsync();
    }
}