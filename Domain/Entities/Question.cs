using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Question
{
    public Guid Id { get; set; }

    public string Content { get; set; } = null!;

    [Range(1, 1000)]
    public int Ordinal { get; set; }

    public string Explanation { get; set; } = null!;

    public string? Suggestion { get; set; } = null!;

    #region Training

    public Guid TrainingId { get; set; }

    public Training Training { get; set; } = null!;

    #endregion

    #region Answer

    public ICollection<Answer> Answers { get; set; } = null!;

    #endregion
}