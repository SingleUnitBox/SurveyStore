using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class EditSurveyJobConfiguration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name2",
                schema: "surveyJobs",
                table: "SurveyJobs",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyJobs_Name2",
                schema: "surveyJobs",
                table: "SurveyJobs",
                newName: "IX_SurveyJobs_Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "surveyJobs",
                table: "SurveyJobs",
                newName: "Name2");

            migrationBuilder.RenameIndex(
                name: "IX_SurveyJobs_Name",
                schema: "surveyJobs",
                table: "SurveyJobs",
                newName: "IX_SurveyJobs_Name2");
        }
    }
}
