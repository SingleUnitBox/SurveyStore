using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Migrations
{
    public partial class EditCalibrationToHaveNullableCalibrationDueDateAndCalibrationInterval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CalibrationInterval",
                schema: "calibrations",
                table: "Calibrations",
                type: "interval",
                nullable: true,
                oldClrType: typeof(TimeSpan),
                oldType: "interval");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CalibrationDueDate",
                schema: "calibrations",
                table: "Calibrations",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "CalibrationInterval",
                schema: "calibrations",
                table: "Calibrations",
                type: "interval",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0),
                oldClrType: typeof(TimeSpan),
                oldType: "interval",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CalibrationDueDate",
                schema: "calibrations",
                table: "Calibrations",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
