using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Surveyors.Core.DAL.Migrations
{
    public partial class AddSurveyor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "surveyors");

            migrationBuilder.CreateTable(
                name: "Surveyors",
                schema: "surveyors",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    FirstName = table.Column<string>(type: "text", nullable: true),
                    Surname = table.Column<string>(type: "text", nullable: true),
                    Position = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Surveyors", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Surveyors",
                schema: "surveyors");
        }
    }
}
