using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Migrations
{
    public partial class AddSurveyorStoreEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "equipment");

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
                    FullName = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SurveyEquipment",
                schema: "equipment",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true),
                    PurchasedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CalibrationDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    CalibrationInterval = table.Column<TimeSpan>(type: "interval", nullable: true),
                    StoreId = table.Column<Guid>(type: "uuid", nullable: true),
                    SurveyorId = table.Column<Guid>(type: "uuid", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    ScreenSize = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Frequency = table.Column<decimal>(type: "numeric", nullable: true),
                    OffRoadMode = table.Column<bool>(type: "boolean", nullable: true),
                    Accuracy = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxRemoteDistance = table.Column<int>(type: "integer", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SurveyEquipment_Stores_StoreId",
                        column: x => x.StoreId,
                        principalSchema: "equipment",
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SurveyEquipment_Surveyors_SurveyorId",
                        column: x => x.SurveyorId,
                        principalSchema: "equipment",
                        principalTable: "Surveyors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyEquipment",
                schema: "equipment");

            migrationBuilder.DropTable(
                name: "Stores",
                schema: "equipment");

            migrationBuilder.DropTable(
                name: "Surveyors",
                schema: "equipment");
        }
    }
}
