namespace Api.Dtos.Attachment;

public class CreateAttachmentDto
{
    public IFormFile File { get; set; } = null!;
}