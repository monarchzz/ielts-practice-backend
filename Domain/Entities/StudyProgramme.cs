using Domain.Enums;

namespace Domain.Entities;

public class StudyProgramme
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public StudyProgrammeType Type { get; set; }

    #region StudyProgrammeSections

    public ICollection<StudyProgrammeSection> StudyProgrammeSections { get; set; } = null!;

    #endregion

    #region Users

    public ICollection<User> Users { get; set; } = null!;

    #endregion
}