using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class EditCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Surveyors_SurveyorId",
                schema: "collections",
                table: "Collection");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collection",
                schema: "collections",
                table: "Collection");

            migrationBuilder.RenameTable(
                name: "Collection",
                schema: "collections",
                newName: "Collections",
                newSchema: "collections");

            migrationBuilder.RenameIndex(
                name: "IX_Collection_SurveyorId",
                schema: "collections",
                table: "Collections",
                newName: "IX_Collections_SurveyorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collections",
                schema: "collections",
                table: "Collections",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collections_Surveyors_SurveyorId",
                schema: "collections",
                table: "Collections",
                column: "SurveyorId",
                principalSchema: "collections",
                principalTable: "Surveyors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_Surveyors_SurveyorId",
                schema: "collections",
                table: "Collections");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Collections",
                schema: "collections",
                table: "Collections");

            migrationBuilder.RenameTable(
                name: "Collections",
                schema: "collections",
                newName: "Collection",
                newSchema: "collections");

            migrationBuilder.RenameIndex(
                name: "IX_Collections_SurveyorId",
                schema: "collections",
                table: "Collection",
                newName: "IX_Collection_SurveyorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Collection",
                schema: "collections",
                table: "Collection",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Surveyors_SurveyorId",
                schema: "collections",
                table: "Collection",
                column: "SurveyorId",
                principalSchema: "collections",
                principalTable: "Surveyors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
