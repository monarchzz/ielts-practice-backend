using System.ComponentModel.DataAnnotations;

namespace Domain.Entities;

public class Attachment
{
    public Guid Id { get; set; }

    public string FileName { get; set; } = null!;

    // public Guid Uuid { get; set; }

    [Range(0, 52428800)] // 50mb
    public long Length { get; set; }

    public string ContentType { get; set; } = null!;

    public string Url { get; set; } = null!;

    #region Manager

    public Manager Manager { get; set; } = null!;

    #endregion

    #region User

    public User User { get; set; } = null!;

    #endregion

    #region Training

    public Training ImageTraining { get; set; } = null!;

    public Training AudioTraining { get; set; } = null!;

    #endregion

    #region UserAnswer

    public UserAnswer UserAnswer { get; set; } = null!;

    #endregion
}