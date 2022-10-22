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
    public DbSet<Training> Training { get; set; } = null!;
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<UserAnswer> UserAnswers { get; set; } = null!;
    public DbSet<UserTraining> UserTraining { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        configurationBuilder.Properties<Gender>().HaveConversion<string>();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        #region Configure Entity

        modelBuilder.Entity<Answer>(answer => { answer.HasKey(x => x.Id); });

        modelBuilder.Entity<Attachment>(attachment => { attachment.HasKey(x => x.Id); });

        modelBuilder.Entity<Censor>(censor => { censor.HasKey(x => x.Id); });

        modelBuilder.Entity<Exam>(exam => { exam.HasKey(x => x.Id); });

        modelBuilder.Entity<Question>(question => { question.HasKey(x => x.Id); });

        modelBuilder.Entity<Training>(training => { training.HasKey(x => x.Id); });

        modelBuilder.Entity<User>(user => { user.HasKey(x => x.Id); });

        modelBuilder.Entity<UserAnswer>(userAnswer => { userAnswer.HasKey(x => x.Id); });

        modelBuilder.Entity<UserTraining>(userTraining => { userTraining.HasKey(x => x.Id); });

        #endregion

        #region Seed

        modelBuilder.Entity<User>().HasData(SeedHelper.SeedData<User>("Seed/Users.json"));

        #endregion
    }
}