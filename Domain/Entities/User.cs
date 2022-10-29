using Domain.Enums;

namespace Domain.Entities;

public class User
{
    public Guid Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public Gender Gender { get; set; }

    public DateTime DateOfBirth { get; set; }

    public bool IsActive { get; set; }

    #region Avatar

    public Guid? AvatarId { get; set; }

    public Attachment? Avatar { get; set; }

    #endregion

    #region Testing

    public ICollection<Testing> Testings { get; set; } = null!;

    #endregion

    #region StudyProgrammes

    public ICollection<StudyProgramme> StudyProgrammes { get; set; } = null!;

    #endregion
}