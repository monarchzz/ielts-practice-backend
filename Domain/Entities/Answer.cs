using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Answer
{
    public Guid Id { get; set; }

    public string? Letter { get; set; }

    public bool IsCorrect { get; set; }

    public string Content { get; set; } = null!;

    #region Question

    public Guid QuestionId { get; set; }

    public Question Question { get; set; } = null!;

    #endregion

    #region UserAnswer

    public ICollection<UserAnswer> UserAnswers { get; set; } = null!;

    #endregion
}