using ErrorOr;

namespace Domain.Common.Errors;

public static partial class Errors
{
    public static class Attachment
    {
        public static Error NotExist => Error.NotFound("Attachment.NotExist", "Attachment does not exist.");

        public static Error UploadFailed => Error.Unexpected("Attachment.UploadFailed", "Attachment upload failed.");
    }
}