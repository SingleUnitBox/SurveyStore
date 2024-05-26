using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class EditSurveyJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                schema: "surveyJobs",
                table: "SurveyJobs");
        }
    }
}
