using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class AddCostToDeliverToSSurveyJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CostToDeliver",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "integer",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CostToDeliver",
                schema: "surveyJobs",
                table: "SurveyJobs");
        }
    }
}
