using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IAnswerRepository : IBaseRepository
{
    Task<Answer?> GertById(Guid id);
}