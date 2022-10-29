using Microsoft.AspNetCore.Http;

namespace Application.Attachments.Common;

public class AttachmentResult
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;

    public int Length { get; set; }

    public string ContentType { get; set; } = null!;

    public string Url { get; set; } = null!;
}