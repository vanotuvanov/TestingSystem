using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestDeveloper.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeTests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeTests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Option",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TestTime = table.Column<int>(type: "int", nullable: false),
                    NumberOfQuestions = table.Column<int>(type: "int", nullable: false),
                    NumberOfEttemps = table.Column<int>(type: "int", nullable: false),
                    KnowledgeTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Option", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Option_KnowledgeTests_KnowledgeTestId",
                        column: x => x.KnowledgeTestId,
                        principalTable: "KnowledgeTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KnowledgeTestId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_KnowledgeTests_KnowledgeTestId",
                        column: x => x.KnowledgeTestId,
                        principalTable: "KnowledgeTests",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MultipleCaseQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    test = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleCaseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleCaseQuestions_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SingleCaseQuestions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleCaseQuestions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleCaseQuestions_Questions_Id",
                        column: x => x.Id,
                        principalTable: "Questions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MultipleCaseAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrueVarriant = table.Column<bool>(type: "bit", nullable: false),
                    MultipleCaseQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultipleCaseAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultipleCaseAnswers_Answers_Id",
                        column: x => x.Id,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_MultipleCaseAnswers_MultipleCaseQuestions_MultipleCaseQuestionId",
                        column: x => x.MultipleCaseQuestionId,
                        principalTable: "MultipleCaseQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SingleCaseAnswers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TrueVarriant = table.Column<bool>(type: "bit", nullable: false),
                    SingleCaseQuestionId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SingleCaseAnswers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SingleCaseAnswers_Answers_Id",
                        column: x => x.Id,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SingleCaseAnswers_SingleCaseQuestions_SingleCaseQuestionId",
                        column: x => x.SingleCaseQuestionId,
                        principalTable: "SingleCaseQuestions",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_MultipleCaseAnswers_MultipleCaseQuestionId",
                table: "MultipleCaseAnswers",
                column: "MultipleCaseQuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Option_KnowledgeTestId",
                table: "Option",
                column: "KnowledgeTestId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_KnowledgeTestId",
                table: "Questions",
                column: "KnowledgeTestId");

            migrationBuilder.CreateIndex(
                name: "IX_SingleCaseAnswers_SingleCaseQuestionId",
                table: "SingleCaseAnswers",
                column: "SingleCaseQuestionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MultipleCaseAnswers");

            migrationBuilder.DropTable(
                name: "Option");

            migrationBuilder.DropTable(
                name: "SingleCaseAnswers");

            migrationBuilder.DropTable(
                name: "MultipleCaseQuestions");

            migrationBuilder.DropTable(
                name: "Answers");

            migrationBuilder.DropTable(
                name: "SingleCaseQuestions");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "KnowledgeTests");
        }
    }
}
