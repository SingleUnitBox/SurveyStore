using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Equipment.Infrastructure.EF.Migrations
{
    public partial class EditSurveyEquipment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CalibrationDate",
                schema: "equipment",
                table: "SurveyEquipment");

            migrationBuilder.DropColumn(
                name: "CalibrationInterval",
                schema: "equipment",
                table: "SurveyEquipment");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CalibrationDate",
                schema: "equipment",
                table: "SurveyEquipment",
                type: "timestamp without time zone",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "CalibrationInterval",
                schema: "equipment",
                table: "SurveyEquipment",
                type: "interval",
                nullable: true);
        }
    }
}
