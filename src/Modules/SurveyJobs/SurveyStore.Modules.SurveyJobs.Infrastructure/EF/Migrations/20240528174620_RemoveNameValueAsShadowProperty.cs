using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class RemoveNameValueAsShadowProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveyJobs_NameValue",
                schema: "surveyJobs",
                table: "SurveyJobs");

            migrationBuilder.DropColumn(
                name: "NameValue",
                schema: "surveyJobs",
                table: "SurveyJobs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NameValue",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyJobs_NameValue",
                schema: "surveyJobs",
                table: "SurveyJobs",
                column: "NameValue",
                unique: true);
        }
    }
}
