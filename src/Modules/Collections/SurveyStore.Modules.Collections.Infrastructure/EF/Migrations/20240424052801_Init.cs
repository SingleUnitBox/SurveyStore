using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Collections.Infrastructure.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "collections");

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "collections",
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
                schema: "collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    FullName = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyEquipment",
                schema: "collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyEquipment_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "collections",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Collections",
                schema: "collections",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyorId = table.Column<Guid>(type: "uuid", nullable: true),
                    CollectionStoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    ReturnStoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    SurveyEquipmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CollectedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    ReturnedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Collections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Collections_Surveyors_SurveyorId",
                        column: x => x.SurveyorId,
                        principalSchema: "collections",
                        principalTable: "Surveyors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Collections_SurveyorId",
                schema: "collections",
                table: "Collections",
                column: "SurveyorId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_StoreId",
                schema: "collections",
                table: "SurveyEquipment",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Collections",
                schema: "collections");

            migrationBuilder.DropTable(
                name: "SurveyEquipment",
                schema: "collections");

            migrationBuilder.DropTable(
                name: "Surveyors",
                schema: "collections");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "collections");
        }
    }
}
