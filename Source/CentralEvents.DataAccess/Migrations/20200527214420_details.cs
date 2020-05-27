using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralEvents.DataAccess.Migrations
{
    public partial class details : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BeginnUhrzeit",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Beschreibung",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Datum",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Eintritt",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "EndeUhrzeit",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ort",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BeginnUhrzeit",
                schema: "DBO",
                table: "CentralEventsTable");

            migrationBuilder.DropColumn(
                name: "Beschreibung",
                schema: "DBO",
                table: "CentralEventsTable");

            migrationBuilder.DropColumn(
                name: "Datum",
                schema: "DBO",
                table: "CentralEventsTable");

            migrationBuilder.DropColumn(
                name: "Eintritt",
                schema: "DBO",
                table: "CentralEventsTable");

            migrationBuilder.DropColumn(
                name: "EndeUhrzeit",
                schema: "DBO",
                table: "CentralEventsTable");

            migrationBuilder.DropColumn(
                name: "Ort",
                schema: "DBO",
                table: "CentralEventsTable");
        }
    }
}
