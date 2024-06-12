using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Payments.Infrastructure.EF.Migrations
{
    public partial class AddSurveyJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "payments");

            migrationBuilder.CreateTable(
                name: "SurveyJobs",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    IssuedAt = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    Budget = table.Column<int>(type: "integer", nullable: true),
                    CostToDeliver = table.Column<int>(type: "integer", nullable: true),
                    Version = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SurveyJobs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SurveyJobs",
                schema: "payments");
        }
    }
}
