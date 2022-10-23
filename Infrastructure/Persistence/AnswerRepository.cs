using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using EFCore;

namespace Infrastructure.Persistence;

public class AnswerRepository : BaseRepository, IAnswerRepository
{
    public AnswerRepository(AppDbContext context) : base(context)
    {
    }

    public Task<Answer?> GertById(Guid id)
    {
        throw new NotImplementedException();
    }
}