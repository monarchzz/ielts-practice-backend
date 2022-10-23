using Domain.Enums;

namespace Domain.Entities;

public class Training
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public TrainingSession TrainingSession { get; set; }

    public TrainingType Type { get; set; }

    public TrainingLevel Level { get; set; }

    public TrainingStatus Status { get; set; }

    public bool ForExamOnly { get; set; }

    #region Audio

    public Guid? AudioId { get; set; }

    public Attachment Audio { get; set; } = null!;

    #endregion

    #region Image

    public Guid? ImageId { get; set; }

    public Attachment Image { get; set; } = null!;

    #endregion

    #region Author

    public Guid? AuthorId { get; set; }

    public Censor Author { get; set; } = null!;

    #endregion

    #region Question

    public ICollection<Question> Questions { get; set; } = null!;

    #endregion

    #region Exams

    public Exam ListeningSessionExam { get; set; } = null!;

    public Exam SpeakingSessionExam { get; set; } = null!;

    #endregion
}