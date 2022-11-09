using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFCore.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Attachments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Length = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "varchar(100)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attachments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyProgrammes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(2000)", nullable: false),
                    Type = table.Column<string>(type: "varchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgrammes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Managers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar(15)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    Role = table.Column<string>(type: "varchar(10)", nullable: false),
                    AvatarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Managers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Managers_Attachments_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(1000)", nullable: false),
                    Gender = table.Column<string>(type: "varchar(10)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    AvatarId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Attachments_AvatarId",
                        column: x => x.AvatarId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StudyProgrammeSections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Ordinal = table.Column<short>(type: "smallint", nullable: false),
                    StudyProgrammeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgrammeSections", x => x.Id);
                    table.CheckConstraint("CK_StudyProgrammeSections_Ordinal_Range", "[Ordinal] >= CAST(1 AS smallint) AND [Ordinal] <= CAST(32767 AS smallint)");
                    table.ForeignKey(
                        name: "FK_StudyProgrammeSections_StudyProgrammes_StudyProgrammeId",
                        column: x => x.StudyProgrammeId,
                        principalTable: "StudyProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Exams",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Exams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Exams_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudyProgrammeUser",
                columns: table => new
                {
                    StudyProgrammesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgrammeUser", x => new { x.StudyProgrammesId, x.UsersId });
                    table.ForeignKey(
                        name: "FK_StudyProgrammeUser_StudyProgrammes_StudyProgrammesId",
                        column: x => x.StudyProgrammesId,
                        principalTable: "StudyProgrammes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyProgrammeUser_Users_UsersId",
                        column: x => x.UsersId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Training",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    TrainingSession = table.Column<string>(type: "varchar(20)", nullable: false),
                    Type = table.Column<string>(type: "varchar(30)", nullable: false),
                    Level = table.Column<string>(type: "varchar(20)", nullable: false),
                    Status = table.Column<string>(type: "varchar(20)", nullable: false),
                    ForExamOnly = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    AudioId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ImageId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StudyProgrammeSectionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Training", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Training_Attachments_AudioId",
                        column: x => x.AudioId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_Attachments_ImageId",
                        column: x => x.ImageId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Training_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Training_StudyProgrammeSections_StudyProgrammeSectionId",
                        column: x => x.StudyProgrammeSectionId,
                        principalTable: "StudyProgrammeSections",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ordinal = table.Column<short>(type: "smallint", nullable: false),
                    Explanation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suggestion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.CheckConstraint("CK_Questions_Ordinal_Range", "[Ordinal] >= CAST(1 AS smallint) AND [Ordinal] <= CAST(1000 AS smallint)");
                    table.ForeignKey(
                        name: "FK_Questions_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Testings",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Duration = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpeakingScores = table.Column<double>(type: "float", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ExamId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TrainingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Testings", x => x.Id);
                    table.CheckConstraint("CK_Testings_SpeakingScores_Range", "[SpeakingScores] >= 0.0E0 AND [SpeakingScores] <= 10.0E0");
                    table.ForeignKey(
                        name: "FK_Testings_Exams_ExamId",
                        column: x => x.ExamId,
                        principalTable: "Exams",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Testings_Managers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Managers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Testings_Training_TrainingId",
                        column: x => x.TrainingId,
                        principalTable: "Training",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Testings_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Letter = table.Column<string>(type: "varchar(1)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Words = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    AudioRecordingId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    TestingId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AnswerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    QuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAnswers_Answers_AnswerId",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_Attachments_AudioRecordingId",
                        column: x => x.AudioRecordingId,
                        principalTable: "Attachments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserAnswers_Testings_TestingId",
                        column: x => x.TestingId,
                        principalTable: "Testings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Attachments",
                columns: new[] { "Id", "ContentType", "FileName", "Length", "Url" },
                values: new object[,]
                {
                    { new Guid("31902f79-115e-4a27-f01a-08dabcf288f9"), "application/octet-stream", "image_picker8481115442505803273.jpg", 91755L, "http://res.cloudinary.com/monarchz/image/upload/v1667410898/ietls/images/image_picker8481115442505803273-57a39641-3df6-4030-936e-189dcb736334.jpg" },
                    { new Guid("6bac9ded-377c-4ff8-f60d-08dab9abd7a2"), "image/jpeg", "ku8nqdzb51k1b5mmnuon.jpg", 91755L, "http://res.cloudinary.com/monarchz/image/upload/v1667047732/ietls/images/ku8nqdzb51k1b5mmnuon-10c8a962-6a2d-4516-b243-3405e63f8023.jpg" },
                    { new Guid("9111ce96-9da2-4cb8-90f7-08dab9773926"), "image/jpeg", "ku8nqdzb51k1b5mmnuon.jpg", 91755L, "http://res.cloudinary.com/monarchz/image/upload/v1667025386/ietls/images/ku8nqdzb51k1b5mmnuon-40a280f4-3a28-4f03-bf16-b6b90d4a2fb0.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "DateOfBirth", "Email", "FirstName", "Gender", "IsActive", "LastName", "Password" },
                values: new object[] { new Guid("c54a474e-ac00-4057-85b2-ed407135d528"), null, new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "user@gmail.com", "User", "Male", true, "Default", "$2a$11$2yetTvA.CA3opcE1Ixr1I.WBqBEZsrl0vI2MWPhAYT6tt0/rf5XWa" });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "AvatarId", "DateOfBirth", "Email", "FirstName", "Gender", "IsActive", "LastName", "Password", "PhoneNumber", "Role" },
                values: new object[] { new Guid("fcb33d6a-177e-4f41-9855-7975c7b77950"), new Guid("6bac9ded-377c-4ff8-f60d-08dab9abd7a2"), new DateTime(2000, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "admin@gmail.com", "Admin", "Female", true, "Default", "$2a$11$2yetTvA.CA3opcE1Ixr1I.WBqBEZsrl0vI2MWPhAYT6tt0/rf5XWa", "0985938085", "Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AvatarId", "DateOfBirth", "Email", "FirstName", "Gender", "IsActive", "LastName", "Password" },
                values: new object[] { new Guid("b6e82736-f3bc-41b0-586c-08dabcf27cfe"), new Guid("31902f79-115e-4a27-f01a-08dabcf288f9"), new DateTime(2000, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "hieunt@gmail.com", "Hieu", "Male", true, "Nguyen", "$2a$11$afcgukPItq13XuA2W/LFvObQxeojtyA2w6VZs9nRU3I0cHSMDkPa2" });

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Exams_ManagerId",
                table: "Exams",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_AvatarId",
                table: "Managers",
                column: "AvatarId",
                unique: true,
                filter: "[AvatarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Managers_Email",
                table: "Managers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_TrainingId",
                table: "Questions",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgrammeSections_StudyProgrammeId",
                table: "StudyProgrammeSections",
                column: "StudyProgrammeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgrammeUser_UsersId",
                table: "StudyProgrammeUser",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_ExamId",
                table: "Testings",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_ManagerId",
                table: "Testings",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_TrainingId",
                table: "Testings",
                column: "TrainingId");

            migrationBuilder.CreateIndex(
                name: "IX_Testings_UserId",
                table: "Testings",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_AudioId",
                table: "Training",
                column: "AudioId",
                unique: true,
                filter: "[AudioId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ExamId",
                table: "Training",
                column: "ExamId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ImageId",
                table: "Training",
                column: "ImageId",
                unique: true,
                filter: "[ImageId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Training_ManagerId",
                table: "Training",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_Training_StudyProgrammeSectionId",
                table: "Training",
                column: "StudyProgrammeSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AnswerId",
                table: "UserAnswers",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_AudioRecordingId",
                table: "UserAnswers",
                column: "AudioRecordingId",
                unique: true,
                filter: "[AudioRecordingId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_QuestionId",
                table: "UserAnswers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAnswers_TestingId",
                table: "UserAnswers",
                column: "TestingId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_AvatarId",
                table: "Users",
                column: "AvatarId",
                unique: true,
                filter: "[AvatarId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyProgrammeUser");

            migrationBuilder.DropTable(
                name: "UserAnswers");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "Testings");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Training");

            migrationBuilder.DropTable(
                name: "Exams");

            migrationBuilder.DropTable(
                name: "StudyProgrammeSections");

            migrationBuilder.DropTable(
                name: "Managers");

            migrationBuilder.DropTable(
                name: "StudyProgrammes");

            migrationBuilder.DropTable(
                name: "Attachments");
        }
    }
}
