using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class AddKitCollection : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KitCollections",
                schema: "collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyorId = table.Column<Guid>(type: "uuid", nullable: true),
                    CollectionStoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReturnStoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    KitId = table.Column<Guid>(type: "uuid", nullable: true),
                    CollectedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReturnedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KitCollections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KitCollections_Kit_KitId",
                        column: x => x.KitId,
                        principalSchema: "collections",
                        principalTable: "Kit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KitCollections_Surveyors_SurveyorId",
                        column: x => x.SurveyorId,
                        principalSchema: "collections",
                        principalTable: "Surveyors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KitCollections_KitId",
                schema: "collections",
                table: "KitCollections",
                column: "KitId");

            migrationBuilder.CreateIndex(
                name: "IX_KitCollections_SurveyorId",
                schema: "collections",
                table: "KitCollections",
                column: "SurveyorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KitCollections",
                schema: "collections");
        }
    }
}
