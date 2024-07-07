using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Calibrations.Infrastructure.EF.Migrations
{
    public partial class EditCalibrationConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CalibrationStatus",
                schema: "calibrations",
                table: "Calibrations",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CalibrationStatus",
                schema: "calibrations",
                table: "Calibrations",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
