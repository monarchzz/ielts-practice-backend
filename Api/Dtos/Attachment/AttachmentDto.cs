namespace Api.Dtos.Attachment;

public class AttachmentDto
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;

    public int Length { get; set; }

    public string ContentType { get; set; } = null!;

    public string Url { get; set; } = null!;
}