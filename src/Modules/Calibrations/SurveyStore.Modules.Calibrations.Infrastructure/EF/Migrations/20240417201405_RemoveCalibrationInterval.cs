using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Migrations
{
    public partial class RemoveCalibrationInterval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalibrationInterval",
                schema: "calibrations",
                table: "Calibrations");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<TimeSpan>(
                name: "CalibrationInterval",
                schema: "calibrations",
                table: "Calibrations",
                type: "interval",
                nullable: true);
        }
    }
}
