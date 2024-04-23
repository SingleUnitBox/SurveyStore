using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class AddSurveyEquipmentType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Type",
                schema: "collections",
                table: "SurveyEquipment",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                schema: "collections",
                table: "SurveyEquipment");
        }
    }
}
