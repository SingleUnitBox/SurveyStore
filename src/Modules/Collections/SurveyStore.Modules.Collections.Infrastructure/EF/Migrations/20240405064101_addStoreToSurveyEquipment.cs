using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class addStoreToSurveyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "collections",
                table: "SurveyEquipment",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyEquipment_Stores_StoreId",
                schema: "collections",
                table: "SurveyEquipment",
                column: "StoreId",
                principalSchema: "collections",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyEquipment_Stores_StoreId",
                schema: "collections",
                table: "SurveyEquipment");

            migrationBuilder.DropIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "collections",
                table: "SurveyEquipment");
        }
    }
}
