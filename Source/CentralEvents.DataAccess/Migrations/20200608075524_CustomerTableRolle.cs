using Microsoft.EntityFrameworkCore.Migrations;

namespace CentralEvents.DataAccess.Migrations
{
    public partial class CustomerTableRolle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Rolle",
                schema: "DBO",
                table: "CustomerTable",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rolle",
                schema: "DBO",
                table: "CustomerTable");
        }
    }
}
