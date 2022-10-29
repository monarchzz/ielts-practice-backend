using Domain.Enums;

namespace Domain.Entities;

public class Exam
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public ExamStatus Status { get; set; }

    #region Author

    public Guid ManagerId { get; set; }

    public Manager Manager { get; set; } = null!;

    #endregion

    #region Testing

    public ICollection<Testing> Testings { get; set; } = null!;

    #endregion

    #region Training

    public ICollection<Training> Trainings { get; set; } = null!;

    #endregion
}