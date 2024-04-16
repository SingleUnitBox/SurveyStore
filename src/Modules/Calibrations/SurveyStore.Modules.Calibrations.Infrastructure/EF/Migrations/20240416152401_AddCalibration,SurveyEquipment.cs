using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Migrations
{
    public partial class AddCalibrationSurveyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "calibrations");

            migrationBuilder.CreateTable(
                name: "SurveyEquipment",
                schema: "calibrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    SerialNumber = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyEquipment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calibrations",
                schema: "calibrations",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SurveyEquipmentId = table.Column<Guid>(type: "uuid", nullable: true),
                    CalibrationDueDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    CalibrationStatus = table.Column<int>(type: "integer", nullable: false),
                    CertificateNumber = table.Column<string>(type: "text", nullable: true),
                    CalibrationInterval = table.Column<TimeSpan>(type: "interval", nullable: false),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calibrations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calibrations_SurveyEquipment_SurveyEquipmentId",
                        column: x => x.SurveyEquipmentId,
                        principalSchema: "calibrations",
                        principalTable: "SurveyEquipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Calibrations_SurveyEquipmentId",
                schema: "calibrations",
                table: "Calibrations",
                column: "SurveyEquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_SurveyEquipment_SerialNumber",
                schema: "calibrations",
                table: "SurveyEquipment",
                column: "SerialNumber",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Calibrations",
                schema: "calibrations");

            migrationBuilder.DropTable(
                name: "SurveyEquipment",
                schema: "calibrations");
        }
    }
}
