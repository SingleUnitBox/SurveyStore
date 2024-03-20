using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Migrations
{
    public partial class EditSurveyEquipmentConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_SerialNumber",
                schema: "equipment",
                table: "SurveyEquipment",
                column: "SerialNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_SurveyEquipment_SerialNumber",
                schema: "equipment",
                table: "SurveyEquipment");
        }
    }
}
