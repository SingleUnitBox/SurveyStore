using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SurveyStore.Modules.Stores.Core.DAL.Migrations
{
    public partial class AddStores : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "stores");

            migrationBuilder.CreateTable(
                name: "Stores",
                schema: "stores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    OpeningTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ClosingTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Stores",
                schema: "stores");
        }
    }
}
