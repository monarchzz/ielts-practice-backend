using Domain.Enums;

namespace Domain.Entities;

public class Exam
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ExamStatus Status { get; set; }

    #region Listening Session

    public Guid ListeningSessionId { get; set; }

    public Training ListeningSession { get; set; } = null!;

    #endregion

    #region Speaking Session

    public Guid SpeakingSessionId { get; set; }

    public Training SpeakingSession { get; set; } = null!;

    #endregion

    #region Author

    public Guid? AuthorId { get; set; }

    public Censor Author { get; set; } = null!;

    #endregion
}