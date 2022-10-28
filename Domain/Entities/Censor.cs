using Domain.Enums;

namespace Domain.Entities;

public class Censor
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Gender Gender { get; set; }

    public string PhoneNumber { get; set; } = null!;

    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; }

    #region Avatar

    public Guid? AvatarId { get; set; }

    public Attachment Avatar { get; set; } = null!;

    #endregion

    #region Exam

    public ICollection<Exam> Exams { get; set; } = null!;

    #endregion

    #region Training

    public ICollection<Training> Trainings { get; set; } = null!;

    #endregion

    #region Testing

    public ICollection<Testing> Testings { get; set; } = null!;

    #endregion
}