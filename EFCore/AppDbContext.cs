using Domain.Entities;
using Domain.Enums;
using EFCore.Common;
using Microsoft.EntityFrameworkCore;

namespace EFCore;

public class AppDbContext : DbContext
{
    public DbSet<Answer> Answers { get; set; } = null!;
    public DbSet<Attachment> Attachments { get; set; } = null!;
    public DbSet<Censor> Censors { get; set; } = null!;
    public DbSet<Exam> Exams { get; set; } = null!;
    public DbSet<Question> Questions { get; set; } = null!;
    public DbSet<StudyProgramme> StudyProgrammes { get; set; } = null!;
    public DbSet<StudyProgrammeSection> StudyProgrammeSections { get; set; } = null!;
    public DbSet<Testing> Testings { get; set; } = null!;
    public DbSet<Training> Training { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserAnswer> UserAnswers { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<ExamStatus>().HaveConversion<string>();
        configurationBuilder.Properties<Gender>().HaveConversion<string>();
        configurationBuilder.Properties<StudyProgrammeType>().HaveConversion<string>();
        configurationBuilder.Properties<TrainingLevel>().HaveConversion<string>();
        configurationBuilder.Properties<TrainingSession>().HaveConversion<string>();
        configurationBuilder.Properties<TrainingStatus>().HaveConversion<string>();
        configurationBuilder.Properties<TrainingType>().HaveConversion<string>();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseValidationCheckConstraints();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Configure Entity

        modelBuilder.Entity<Answer>(answer =>
        {
            answer.HasKey(x => x.Id);
            answer.Property(x => x.Letter).IsRequired(false).HasColumnType("varchar(1)");
            answer.Property(x => x.IsCorrect).IsRequired();
            answer.Property(x => x.Content).IsRequired();
            answer.Property(x => x.QuestionId).IsRequired();

            answer.HasOne(x => x.Question).WithMany(x => x.Answers).HasForeignKey(x => x.QuestionId);
        });

        modelBuilder.Entity<Attachment>(attachment =>
        {
            attachment.HasKey(x => x.Id);
            attachment.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(200)");
            attachment.Property(x => x.FileName).IsRequired().HasColumnType("nvarchar(200)");
            // attachment.Property(x => x.Uuid).IsRequired();
            attachment.Property(x => x.Length).IsRequired();
            attachment.Property(x => x.ContentType).IsRequired().HasColumnType("varchar(100)");
        });

        modelBuilder.Entity<Censor>(censor =>
        {
            censor.HasKey(x => x.Id);
            censor.HasIndex(x => x.Email).IsUnique();

            censor.Property(x => x.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            censor.Property(x => x.LastName).IsRequired().HasColumnType("nvarchar(50)");
            censor.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(50)");
            censor.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(1000)");
            censor.Property(x => x.Gender).IsRequired().HasColumnType("varchar(10)");
            censor.Property(x => x.PhoneNumber).IsRequired(false).HasColumnType("varchar(15)");
            censor.Property(x => x.AvatarId).IsRequired(false);

            censor.HasOne(x => x.Avatar).WithOne(x => x.Censor)
                .HasForeignKey<Censor>(x => x.AvatarId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Exam>(exam =>
        {
            exam.HasKey(x => x.Id);

            exam.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(200)");
            exam.Property(x => x.Status).IsRequired().HasColumnType("varchar(20)");
            exam.Property(x => x.CensorId).IsRequired();

            exam.HasOne(x => x.Censor).WithMany(x => x.Exams).HasForeignKey(x => x.CensorId);
        });

        modelBuilder.Entity<Question>(question =>
        {
            question.HasKey(x => x.Id);

            question.Property(x => x.Content).IsRequired();
            question.Property(x => x.Ordinal).IsRequired().HasColumnType("smallint");
            question.Property(x => x.Explanation).IsRequired();
            question.Property(x => x.Suggestion).IsRequired(false);
            question.Property(x => x.TrainingId).IsRequired();

            question.HasOne(x => x.Training).WithMany(x => x.Questions).HasForeignKey(x => x.TrainingId);
        });

        modelBuilder.Entity<StudyProgramme>(studyProgramme =>
        {
            studyProgramme.HasKey(x => x.Id);

            studyProgramme.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(200)");
            studyProgramme.Property(x => x.Description).IsRequired().HasColumnType("nvarchar(2000)");
            studyProgramme.Property(x => x.Type).IsRequired().HasColumnType("varchar(50)");
        });

        modelBuilder.Entity<StudyProgrammeSection>(studyProgrammeSection =>
        {
            studyProgrammeSection.HasKey(x => x.Id);

            studyProgrammeSection.Property(x => x.Title).IsRequired().HasColumnType("nvarchar(200)");
            studyProgrammeSection.Property(x => x.Ordinal).IsRequired().HasColumnType("smallint");
            studyProgrammeSection.Property(x => x.StudyProgrammeId).IsRequired();

            studyProgrammeSection.HasOne(x => x.StudyProgramme).WithMany(x => x.StudyProgrammeSections)
                .HasForeignKey(x => x.StudyProgrammeId);
        });

        modelBuilder.Entity<Testing>(testing =>
        {
            testing.HasKey(x => x.Id);

            testing.Property(x => x.Duration).IsRequired().HasConversion<long>();
            testing.Property(x => x.Date).IsRequired();
            testing.Property(x => x.SpeakingScores).IsRequired(false);
            testing.Property(x => x.UserId).IsRequired();
            testing.Property(x => x.CensorId).IsRequired(false);
            testing.Property(x => x.ExamId).IsRequired(false);
            testing.Property(x => x.TrainingId).IsRequired(false);

            testing.HasOne(x => x.User).WithMany(x => x.Testings).HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.NoAction);
            testing.HasOne(x => x.Censor).WithMany(x => x.Testings).HasForeignKey(x => x.CensorId)
                .OnDelete(DeleteBehavior.NoAction);
            testing.HasOne(x => x.Exam).WithMany(x => x.Testings).HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.NoAction);
            testing.HasOne(x => x.Training).WithMany(x => x.Testings).HasForeignKey(x => x.TrainingId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Training>(training =>
        {
            training.HasKey(x => x.Id);

            training.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(200)");
            training.Property(x => x.TrainingSession).IsRequired().HasColumnType("varchar(20)");
            training.Property(x => x.Type).IsRequired().HasColumnType("varchar(30)");
            training.Property(x => x.Level).IsRequired().HasColumnType("varchar(20)");
            training.Property(x => x.Status).IsRequired().HasColumnType("varchar(20)");
            training.Property(x => x.ForExamOnly).IsRequired().HasDefaultValue(false);
            training.Property(x => x.ImageId).IsRequired(false);
            training.Property(x => x.AudioId).IsRequired(false);
            training.Property(x => x.CensorId).IsRequired();
            training.Property(x => x.ExamId).IsRequired(false);
            training.Property(x => x.StudyProgrammeSectionId).IsRequired(false);

            training.HasOne(x => x.Censor).WithMany(x => x.Trainings).HasForeignKey(x => x.CensorId);
            training.HasOne(x => x.Exam).WithMany(x => x.Trainings).HasForeignKey(x => x.ExamId)
                .OnDelete(DeleteBehavior.NoAction);
            training.HasOne(x => x.Image).WithOne(x => x.ImageTraining).HasForeignKey<Training>(x => x.ImageId)
                .OnDelete(DeleteBehavior.NoAction);
            training.HasOne(x => x.Audio).WithOne(x => x.AudioTraining).HasForeignKey<Training>(x => x.AudioId)
                .OnDelete(DeleteBehavior.NoAction);
            training.HasOne(x => x.StudyProgrammeSection).WithMany(x => x.Trainings)
                .HasForeignKey(X => X.StudyProgrammeSectionId).OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<User>(user =>
        {
            user.HasKey(x => x.Id);
            user.HasIndex(x => x.Email).IsUnique();

            user.Property(x => x.FirstName).IsRequired().HasColumnType("nvarchar(50)");
            user.Property(x => x.LastName).IsRequired().HasColumnType("nvarchar(50)");
            user.Property(x => x.Email).IsRequired().HasColumnType("nvarchar(50)");
            user.Property(x => x.Password).IsRequired().HasColumnType("nvarchar(1000)");
            user.Property(x => x.Gender).IsRequired().HasColumnType("varchar(10)");
            user.Property(x => x.AvatarId).IsRequired(false);

            user.HasOne(x => x.Avatar).WithOne(x => x.User).HasForeignKey<User>(x => x.AvatarId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<UserAnswer>(userAnswer =>
        {
            userAnswer.HasKey(x => x.Id);

            userAnswer.Property(x => x.Words).IsRequired().HasColumnType("nvarchar(500)");
            userAnswer.Property(x => x.AnswerId).IsRequired();
            userAnswer.Property(x => x.AudioRecordingId).IsRequired(false);
            userAnswer.Property(x => x.TestingId).IsRequired();
            userAnswer.Property(x => x.QuestionId).IsRequired();
            userAnswer.Property(x => x.AnswerId).IsRequired(false);

            userAnswer.HasOne(x => x.AudioRecording).WithOne(x => x.UserAnswer)
                .HasForeignKey<UserAnswer>(x => x.AudioRecordingId).OnDelete(DeleteBehavior.NoAction);
            userAnswer.HasOne(x => x.Testing).WithMany(x => x.UserAnswers).HasForeignKey(x => x.TestingId);
            userAnswer.HasOne(x => x.Answer).WithMany(x => x.UserAnswers).HasForeignKey(x => x.AnswerId);
            userAnswer.HasOne(x => x.Question).WithMany(x => x.UserAnswers).HasForeignKey(x => x.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        #endregion

        #region Seed

        modelBuilder.Entity<User>().HasData(SeedHelper.SeedData<User>("Seed/Users.json"));

        #endregion
    }
}