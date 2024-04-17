using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Migrations
{
    public partial class EditCalibrationConfigurationToHaveCalibrationStatusAsString : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CalibrationStatus",
                schema: "calibrations",
                table: "Calibrations",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "CalibrationStatus",
                schema: "calibrations",
                table: "Calibrations",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
