using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Migrations
{
    public partial class EditSurveyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "equipment");

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
                    Type = table.Column<string>(type: "text", nullable: false),
                    ScreenSize = table.Column<int>(type: "integer", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: true),
                    Frequency = table.Column<decimal>(type: "numeric", nullable: true),
                    OffRoadMode = table.Column<bool>(type: "boolean", nullable: true),
                    Accuracy = table.Column<decimal>(type: "numeric", nullable: true),
                    MaxRemoteDistance = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyEquipment", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyEquipment",
                schema: "equipment");
        }
    }
}
