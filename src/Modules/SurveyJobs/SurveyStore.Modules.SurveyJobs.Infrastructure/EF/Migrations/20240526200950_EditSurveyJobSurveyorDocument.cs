using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class EditSurveyJobSurveyorDocument : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "surveyJobs");

            migrationBuilder.CreateTable(
                name: "SurveyJobs",
                schema: "surveyJobs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    BriefIssued = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    SurveyType = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyJobs", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "SurveyJobSurveyor",
                schema: "surveyJobs",
                columns: table => new
                {
                    SurveyJobsId = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyorsId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyJobSurveyor", x => new { x.SurveyJobsId, x.SurveyorsId });
                    table.ForeignKey(
                        name: "FK_SurveyJobSurveyor_SurveyJobs_SurveyJobsId",
                        column: x => x.SurveyJobsId,
                        principalSchema: "surveyJobs",
                        principalTable: "SurveyJobs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SurveyJobSurveyor_Surveyors_SurveyorsId",
                        column: x => x.SurveyorsId,
                        principalSchema: "surveyJobs",
                        principalTable: "Surveyors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Documents_SurveyJobId",
                schema: "surveyJobs",
                table: "Documents",
                column: "SurveyJobId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyJobSurveyor_SurveyorsId",
                schema: "surveyJobs",
                table: "SurveyJobSurveyor",
                column: "SurveyorsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documents",
                schema: "surveyJobs");

            migrationBuilder.DropTable(
                name: "SurveyJobSurveyor",
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
