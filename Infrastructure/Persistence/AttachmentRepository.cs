using System.Linq.Expressions;
using Application.Common.Interfaces.Persistence;
using Domain.Entities;
using EFCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence;

public class AttachmentRepository : BaseRepository, IAttachmentRepository
{
    private readonly DbSet<Attachment> _attachments;

    private readonly IQueryable<Attachment> _attachmentsQueryable;

    public AttachmentRepository(AppDbContext context) : base(context)
    {
        _attachments = Context.Attachments;
        _attachmentsQueryable = _attachments.AsNoTracking();
    }

    public Task<bool> ExistsAsync(Expression<Func<Attachment, bool>> predicate)
    {
        return _attachmentsQueryable.AnyAsync(predicate);
    }

    public Task<Attachment?> GetByIdAsync(Guid id)
    {
        return _attachmentsQueryable
            .Include(x => x.User)
            .Include(x => x.Manager)
            .Include(x => x.ImageTraining)
            .Include(x => x.AudioTraining)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(Attachment attachment)
    {
        await _attachments.AddAsync(attachment);
    }

    public void Update(Attachment attachment)
    {
        _attachments.Update(attachment);
    }

    public void Remove(Attachment attachment)
    {
        _attachments.Remove(attachment);
    }
}