using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Activity
{
    public Guid Id { get; set; }

    public TimeSpan Duration { get; set; }

    public DateTime Date { get; set; }

    [Range(0, 10.0)]
    public double SpeakingScores { get; set; }

    #region User

    public Guid UserId { get; set; }

    public User User { get; set; } = null!;

    #endregion

    #region UserAnswers

    public ICollection<UserAnswer> UserAnswers { get; set; } = null!;

    #endregion
}