using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Migrations
{
    public partial class RemoveStoreAndSurveyor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SurveyEquipment_Stores_StoreId",
                schema: "equipment",
                table: "SurveyEquipment");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyEquipment_Surveyors_SurveyorId",
                schema: "equipment",
                table: "SurveyEquipment");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "equipment");

            migrationBuilder.DropTable(
                name: "Surveyors",
                schema: "equipment");

            migrationBuilder.DropIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "equipment",
                table: "SurveyEquipment");

            migrationBuilder.DropIndex(
                name: "IX_SurveyEquipment_SurveyorId",
                schema: "equipment",
                table: "SurveyEquipment");

            migrationBuilder.DropColumn(
                name: "StoreId",
                schema: "equipment",
                table: "SurveyEquipment");

            migrationBuilder.DropColumn(
                name: "SurveyorId",
                schema: "equipment",
                table: "SurveyEquipment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                schema: "equipment",
                table: "SurveyEquipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SurveyorId",
                schema: "equipment",
                table: "SurveyEquipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Surveyors",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "equipment",
                table: "SurveyEquipment",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_SurveyorId",
                schema: "equipment",
                table: "SurveyEquipment",
                column: "SurveyorId");

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyEquipment_Stores_StoreId",
                schema: "equipment",
                table: "SurveyEquipment",
                column: "StoreId",
                principalSchema: "equipment",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SurveyEquipment_Surveyors_SurveyorId",
                schema: "equipment",
                table: "SurveyEquipment",
                column: "SurveyorId",
                principalSchema: "equipment",
                principalTable: "Surveyors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
