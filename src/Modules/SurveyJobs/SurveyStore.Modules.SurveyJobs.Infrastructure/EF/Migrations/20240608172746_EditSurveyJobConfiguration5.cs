using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class EditSurveyJobConfiguration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveyJobs_Name",
                schema: "surveyJobs",
                table: "SurveyJobs");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyJobs_Name_BriefIssued",
                schema: "surveyJobs",
                table: "SurveyJobs",
                columns: new[] { "Name", "BriefIssued" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveyJobs_Name_BriefIssued",
                schema: "surveyJobs",
                table: "SurveyJobs");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyJobs_Name",
                schema: "surveyJobs",
                table: "SurveyJobs",
                column: "Name",
                unique: true);
        }
    }
}
