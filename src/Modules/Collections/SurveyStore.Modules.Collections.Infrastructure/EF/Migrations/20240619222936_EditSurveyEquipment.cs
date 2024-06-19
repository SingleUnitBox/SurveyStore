using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class EditSurveyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_SurveyEquipment_SurveyEquipmentId",
                schema: "collections",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_SurveyEquipmentId",
                schema: "collections",
                table: "Collections");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Collections_SurveyEquipmentId",
                schema: "collections",
                table: "Collections",
                column: "SurveyEquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_SurveyEquipment_SurveyEquipmentId",
                schema: "collections",
                table: "Collections",
                column: "SurveyEquipmentId",
                principalSchema: "collections",
                principalTable: "SurveyEquipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
