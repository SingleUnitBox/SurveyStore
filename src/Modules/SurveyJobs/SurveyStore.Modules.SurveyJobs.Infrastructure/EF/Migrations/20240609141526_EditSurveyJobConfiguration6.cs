using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.SurveyJobs.Infrastructure.EF.Migrations
{
    public partial class EditSurveyJobConfiguration6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AlterColumn<DateTime>(
                name: "BriefIssued",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "timestamp without time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone");

            migrationBuilder.AddColumn<DateTime>(
                name: "IssuedAt",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "timestamp without time zone",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IssuedAt",
                schema: "surveyJobs",
                table: "SurveyJobs");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BriefIssued",
                schema: "surveyJobs",
                table: "SurveyJobs",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true);
        }
    }
}
