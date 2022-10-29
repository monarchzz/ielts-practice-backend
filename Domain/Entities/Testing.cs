using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Testing
{
    public Guid Id { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime Date { get; set; }

    [Range(0, 10.0)]
    public double? SpeakingScores { get; set; }

    #region User

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    #endregion

    #region Censor

    public Guid? CensorId { get; set; }

    public Censor? Censor { get; set; }

    #endregion

    #region Exam

    public Guid? ExamId { get; set; }

    public Exam? Exam { get; set; }

    #endregion

    #region Training

    public Guid? TrainingId { get; set; }

    public Training? Training { get; set; }

    #endregion

    #region UserAnswers

    public ICollection<UserAnswer> UserAnswers { get; set; } = null!;

    #endregion
}