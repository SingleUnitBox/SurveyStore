using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class EditSurveyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "collections",
                table: "SurveyEquipment",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Version",
                schema: "collections",
                table: "SurveyEquipment");
        }
    }
}
