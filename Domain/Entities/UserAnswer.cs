namespace Domain.Entities;

public class UserAnswer
{
    public Guid Id { get; set; }

    public string? Words { get; set; }

    #region Answer

    public Guid AnswerId { get; set; }

    public Answer Answer { get; set; } = null!;

    #endregion

    #region Audio Recording

    public Guid? AudioRecordingId { get; set; }

    public Attachment AudioRecording { get; set; } = null!;

    #endregion

    #region Activity

    public Guid ActivityId { get; set; }

    public Activity Activity { get; set; } = null!;

    #endregion
}