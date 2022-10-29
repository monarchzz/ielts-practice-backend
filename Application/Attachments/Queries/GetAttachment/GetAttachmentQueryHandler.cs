using Application.Attachments.Common;
using Application.Common.Interfaces.Persistence;
using Domain.Common.Errors;
using MediatR;
using ErrorOr;
using MapsterMapper;

namespace Application.Attachments.Queries.GetAttachment;

public class GetAttachmentQueryHandler : IRequestHandler<GetAttachmentQuery, ErrorOr<AttachmentResult>>
{
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly IMapper _mapper;

    public GetAttachmentQueryHandler(IAttachmentRepository attachmentRepository, IMapper mapper)
    {
        _attachmentRepository = attachmentRepository;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AttachmentResult>> Handle(GetAttachmentQuery request, CancellationToken cancellationToken)
    {
        var attachment = await _attachmentRepository.GetByIdAsync(request.Id);
        if (attachment == null) return Errors.Attachment.NotExist;

        return _mapper.Map<AttachmentResult>(attachment);
    }
}