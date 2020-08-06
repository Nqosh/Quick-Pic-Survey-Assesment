using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace QuickPicSurvey.API.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Objectives",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Expectation = table.Column<int>(nullable: false),
                    QuestionID = table.Column<int>(nullable: false),
                    Question = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Objectives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RespondentResults",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RespondentId = table.Column<int>(nullable: false),
                    QuestionId = table.Column<int>(nullable: false),
                    RespondentsWeight = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespondentResults", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Respondents",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    FirstName = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    LastChangedBy = table.Column<string>(nullable: true),
                    LastChangedDate = table.Column<DateTime>(nullable: false),
                    RespondentResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Respondents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Respondents_RespondentResults_RespondentResultId",
                        column: x => x.RespondentResultId,
                        principalTable: "RespondentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Description = table.Column<string>(nullable: true),
                    LastChangedBy = table.Column<string>(nullable: true),
                    LastChangedDate = table.Column<DateTime>(nullable: false),
                    RespondentId = table.Column<int>(nullable: true),
                    RespondentResultId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_Respondents_RespondentId",
                        column: x => x.RespondentId,
                        principalTable: "Respondents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Questions_RespondentResults_RespondentResultId",
                        column: x => x.RespondentResultId,
                        principalTable: "RespondentResults",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Questions_RespondentId",
                table: "Questions",
                column: "RespondentId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_RespondentResultId",
                table: "Questions",
                column: "RespondentResultId");

            migrationBuilder.CreateIndex(
                name: "IX_Respondents_RespondentResultId",
                table: "Respondents",
                column: "RespondentResultId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Objectives");

            migrationBuilder.DropTable(
                name: "Questions");

            migrationBuilder.DropTable(
                name: "Respondents");

            migrationBuilder.DropTable(
                name: "RespondentResults");
        }
    }
}
