using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class AddSurveyJobsDocumentSurveyor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "surveyJobs");

            migrationBuilder.CreateTable(
                name: "Surveyors",
                schema: "surveyJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyJobs",
                schema: "surveyJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyorId = table.Column<Guid>(type: "uuid", nullable: true),
                    BriefIssued = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SurveyType = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyJobs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyJobs_Surveyors_SurveyorId",
                        column: x => x.SurveyorId,
                        principalSchema: "surveyJobs",
                        principalTable: "Surveyors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                schema: "surveyJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DocumentType = table.Column<string>(type: "text", nullable: true),
                    Link = table.Column<string>(type: "text", nullable: true),
                    SurveyJobId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_SurveyJobs_SurveyJobId",
                        column: x => x.SurveyJobId,
                        principalSchema: "surveyJobs",
                        principalTable: "SurveyJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_SurveyJobId",
                schema: "surveyJobs",
                table: "Documents",
                column: "SurveyJobId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyJobs_SurveyorId",
                schema: "surveyJobs",
                table: "SurveyJobs",
                column: "SurveyorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents",
                schema: "surveyJobs");

            migrationBuilder.DropTable(
                name: "SurveyJobs",
                schema: "surveyJobs");

            migrationBuilder.DropTable(
                name: "Surveyors",
                schema: "surveyJobs");
        }
    }
}
