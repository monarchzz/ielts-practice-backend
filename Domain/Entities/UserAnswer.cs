namespace Domain.Entities;

public class UserAnswer
{
    public Guid Id { get; set; }

    public string? Words { get; set; }

    #region Audio Recording

    public Guid? AudioRecordingId { get; set; }

    public Attachment? AudioRecording { get; set; }

    #endregion

    #region Testing

    public Guid TestingId { get; set; }

    public Testing Testing { get; set; } = null!;

    #endregion

    #region Answer

    public Guid? AnswerId { get; set; }

    public Answer? Answer { get; set; }

    #endregion

    #region Question

    public Guid QuestionId { get; set; }

    public Question Question { get; set; } = null!;

    #endregion
}