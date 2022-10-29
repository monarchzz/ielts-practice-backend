using Application.Attachments.Common;
using Application.Common.Interfaces.Persistence;
using Application.Common.Interfaces.Services;
using Domain.Common.Errors;
using Domain.Entities;
using ErrorOr;
using MapsterMapper;
using MediatR;

namespace Application.Attachments.Commands.ImageUpload;

public class ImageUploadCommandHandler : IRequestHandler<ImageUploadCommand, ErrorOr<AttachmentResult>>
{
    private readonly IAttachmentRepository _attachmentRepository;
    private readonly IAttachmentProvider _attachmentProvider;

    private readonly IMapper _mapper;

    public ImageUploadCommandHandler(IAttachmentRepository attachmentRepository, IAttachmentProvider attachmentProvider,
        IMapper mapper)
    {
        _attachmentRepository = attachmentRepository;
        _attachmentProvider = attachmentProvider;
        _mapper = mapper;
    }

    public async Task<ErrorOr<AttachmentResult>> Handle(ImageUploadCommand command, CancellationToken cancellationToken)
    {
        if (command.File.Length > 52428800)
            return Errors.Attachment.UploadFailed;

        var url = _attachmentProvider.ImageUpload(command.File);
        if (url == null) return Errors.Attachment.UploadFailed;

        var attachment = new Attachment
        {
            FileName = command.File.FileName,
            Length = command.File.Length,
            ContentType = command.File.ContentType,
            Url = url,
        };

        await _attachmentRepository.AddAsync(attachment);
        await _attachmentRepository.SaveChangesAsync();

        return _mapper.Map<AttachmentResult>(attachment);
    }
}