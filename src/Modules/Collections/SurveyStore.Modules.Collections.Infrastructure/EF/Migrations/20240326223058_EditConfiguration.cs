using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class EditConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Collection_Stores_StoreId",
                schema: "collections",
                table: "Collection");

            migrationBuilder.DropForeignKey(
                name: "FK_Collection_SurveyEquipment_SurveyEquipmentId",
                schema: "collections",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Collection_StoreId",
                schema: "collections",
                table: "Collection");

            migrationBuilder.DropIndex(
                name: "IX_Collection_SurveyEquipmentId",
                schema: "collections",
                table: "Collection");

            migrationBuilder.RenameColumn(
                name: "StoreId",
                schema: "collections",
                table: "Collection",
                newName: "ReturnStoreId");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                schema: "collections",
                table: "SurveyEquipment",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CollectionStoreId",
                schema: "collections",
                table: "Collection",
                type: "uuid",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StoreId",
                schema: "collections",
                table: "SurveyEquipment");

            migrationBuilder.DropColumn(
                name: "CollectionStoreId",
                schema: "collections",
                table: "Collection");

            migrationBuilder.RenameColumn(
                name: "ReturnStoreId",
                schema: "collections",
                table: "Collection",
                newName: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_StoreId",
                schema: "collections",
                table: "Collection",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Collection_SurveyEquipmentId",
                schema: "collections",
                table: "Collection",
                column: "SurveyEquipmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_Stores_StoreId",
                schema: "collections",
                table: "Collection",
                column: "StoreId",
                principalSchema: "collections",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Collection_SurveyEquipment_SurveyEquipmentId",
                schema: "collections",
                table: "Collection",
                column: "SurveyEquipmentId",
                principalSchema: "collections",
                principalTable: "SurveyEquipment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
