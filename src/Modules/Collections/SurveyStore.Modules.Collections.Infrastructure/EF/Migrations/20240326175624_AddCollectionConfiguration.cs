using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class AddCollectionConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Collection",
                schema: "collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyorId = table.Column<Guid>(type: "uuid", nullable: true),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    SurveyEquipmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CollectedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReturnedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collection_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "collections",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Collection_SurveyEquipment_SurveyEquipmentId",
                        column: x => x.SurveyEquipmentId,
                        principalSchema: "collections",
                        principalTable: "SurveyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Collection_Surveyors_SurveyorId",
                        column: x => x.SurveyorId,
                        principalSchema: "collections",
                        principalTable: "Surveyors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Collection_SurveyorId",
                schema: "collections",
                table: "Collection",
                column: "SurveyorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collection",
                schema: "collections");
        }
    }
}
