using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralEvents.DataAccess.Migrations
{
    public partial class AnzahlTickets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GesamtanzahlEintrittskarten",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Restbestand",
                schema: "DBO",
                table: "CentralEventsTable",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GesamtanzahlEintrittskarten",
                schema: "DBO",
                table: "CentralEventsTable");

            migrationBuilder.DropColumn(
                name: "Restbestand",
                schema: "DBO",
                table: "CentralEventsTable");
        }
    }
}
