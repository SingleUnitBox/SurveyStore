using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class EditKitConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Kit_Stores_StoreId",
                schema: "collections",
                table: "Kit");

            migrationBuilder.DropIndex(
                name: "IX_Kit_StoreId",
                schema: "collections",
                table: "Kit");

            migrationBuilder.DropColumn(
                name: "StoreId",
                schema: "collections",
                table: "Kit");

            migrationBuilder.DropColumn(
                name: "Version",
                schema: "collections",
                table: "Kit");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KitCollections_Kit_KitId",
                schema: "collections",
                table: "KitCollections");

            migrationBuilder.DropIndex(
                name: "IX_KitCollections_KitId",
                schema: "collections",
                table: "KitCollections");

            migrationBuilder.AddColumn<Guid>(
                name: "StoreId",
                schema: "collections",
                table: "Kit",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Version",
                schema: "collections",
                table: "Kit",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Kit_StoreId",
                schema: "collections",
                table: "Kit",
                column: "StoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Kit_Stores_StoreId",
                schema: "collections",
                table: "Kit",
                column: "StoreId",
                principalSchema: "collections",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
