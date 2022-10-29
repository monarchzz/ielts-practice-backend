using Microsoft.AspNetCore.Http;

namespace Application.Common.Interfaces.Services;

public interface IAttachmentProvider
{
    string? ImageUpload(IFormFile file);

    string? AudioUpload(IFormFile file);
}