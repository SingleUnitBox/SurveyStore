using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class ChangeSurveyEquipmentToEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitCollections_Kit_KitId",
                schema: "collections",
                table: "KitCollections");

            migrationBuilder.DropForeignKey(
                name: "FK_SurveyEquipment_Stores_StoreId",
                schema: "collections",
                table: "SurveyEquipment");

            migrationBuilder.DropIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "collections",
                table: "SurveyEquipment");

            migrationBuilder.DropIndex(
                name: "IX_KitCollections_KitId",
                schema: "collections",
                table: "KitCollections");

            migrationBuilder.DropColumn(
                name: "StoreId",
                schema: "collections",
                table: "SurveyEquipment");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "collections",
                table: "SurveyEquipment");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collections_SurveyEquipment_SurveyEquipmentId",
                schema: "collections",
                table: "Collections");

            migrationBuilder.DropIndex(
                name: "IX_Collections_SurveyEquipmentId",
                schema: "collections",
                table: "Collections");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                schema: "collections",
                table: "SurveyEquipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "collections",
                table: "SurveyEquipment",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "collections",
                table: "SurveyEquipment",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_KitCollections_KitId",
                schema: "collections",
                table: "KitCollections",
                column: "KitId");

            migrationBuilder.AddForeignKey(
                name: "FK_KitCollections_Kit_KitId",
                schema: "collections",
                table: "KitCollections",
                column: "KitId",
                principalSchema: "collections",
                principalTable: "Kit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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
    }
}
