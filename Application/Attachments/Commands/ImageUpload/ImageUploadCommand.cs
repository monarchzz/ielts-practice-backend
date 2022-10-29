using Application.Attachments.Common;
using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Attachments.Commands.ImageUpload;

public class ImageUploadCommand : IRequest<ErrorOr<AttachmentResult>>
{
    public IFormFile File { get; set; } = null!;
}