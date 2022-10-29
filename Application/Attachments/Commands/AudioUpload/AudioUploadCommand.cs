using Application.Attachments.Common;
using MediatR;
using Microsoft.AspNetCore.Http;
using ErrorOr;

namespace Application.Attachments.Commands.AudioUpload;

public class AudioUploadCommand : IRequest<ErrorOr<AttachmentResult>>
{
    public IFormFile File { get; set; } = null!;
}