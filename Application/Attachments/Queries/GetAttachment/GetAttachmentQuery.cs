using Application.Attachments.Common;
using MediatR;
using ErrorOr;

namespace Application.Attachments.Queries.GetAttachment;

public class GetAttachmentQuery: IRequest<ErrorOr<AttachmentResult>>
{
    public Guid Id { get; set; }
}