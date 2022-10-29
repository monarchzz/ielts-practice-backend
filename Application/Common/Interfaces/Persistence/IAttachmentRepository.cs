using System.Linq.Expressions;
using Domain.Entities;

namespace Application.Common.Interfaces.Persistence;

public interface IAttachmentRepository : IBaseRepository
{
    Task<bool> ExistsAsync(Expression<Func<Attachment, bool>> predicate);

    Task<Attachment?> GetByIdAsync(Guid id);

    Task AddAsync(Attachment attachment);

    void Update(Attachment device);

    void Remove(Attachment device);
}