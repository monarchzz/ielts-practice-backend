using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace Domain.Entities;

public class StudyProgrammeSection
{
    public Guid Id { get; set; }

    public string Title { get; set; } = null!;

    [Range(1, short.MaxValue)]
    public int Ordinal { get; set; }

    #region StudyProgramme

    public Guid StudyProgrammeId { get; set; }

    public StudyProgramme StudyProgramme { get; set; } = null!;

    #endregion

    #region Training

    public ICollection<Training> Trainings { get; set; } = null!;

    #endregion
}