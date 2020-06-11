using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralEvents.DataAccess.Migrations
{
    public partial class InitDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "DBO");

            migrationBuilder.CreateTable(
                name: "BookingDetailsTable",
                schema: "DBO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AnzahlTickets = table.Column<int>(type: "int", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hausnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetailsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CentralEventsTable",
                schema: "DBO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beschreibung = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Datum = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BeginnUhrzeit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EndeUhrzeit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Eintritt = table.Column<double>(type: "float", nullable: false),
                    GesamtanzahlEintrittskarten = table.Column<int>(type: "int", nullable: false),
                    Restbestand = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentralEventsTable", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CustomerTable",
                schema: "DBO",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Vorname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nachname = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Strasse = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Hausnummer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Plz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Ort = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Benutzername = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Passwort = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerTable", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "DBO",
                table: "CustomerTable",
                columns: new[] { "Id", "Benutzername", "Email", "Hausnummer", "Nachname", "Ort", "Passwort", "Plz", "Strasse", "Telefon", "Vorname" },
                values: new object[] { new Guid("00000000-0000-0000-0000-000000000001"), "ceUser", "Hans.Werner@freemail.de", "66a", "Werner", "Bremen", "lUgM3gwaOyfgUGaOB300LtJKsbYamO+hZGrdQVZkIYk=", "28759", "Bremerstraße", "0421-555 888 22", "Hans" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetailsTable",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "CentralEventsTable",
                schema: "DBO");

            migrationBuilder.DropTable(
                name: "CustomerTable",
                schema: "DBO");
        }
    }
}
