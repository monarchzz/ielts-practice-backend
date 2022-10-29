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

    public Attachment? Audio { get; set; }

    #endregion

    #region Image

    public Guid? ImageId { get; set; }

    public Attachment? Image { get; set; }

    #endregion

    #region Manager

    public Guid ManagerId { get; set; }

    public Manager Manager { get; set; } = null!;

    #endregion

    #region Exam

    public Guid? ExamId { get; set; }

    public Exam? Exam { get; set; }

    #endregion

    #region StudyProgammeSection

    public Guid? StudyProgrammeSectionId { get; set; }

    public StudyProgrammeSection? StudyProgrammeSection { get; set; }

    #endregion

    #region Question

    public ICollection<Question> Questions { get; set; } = null!;

    #endregion

    #region Testing

    public ICollection<Testing> Testings { get; set; } = null!;

    #endregion
}