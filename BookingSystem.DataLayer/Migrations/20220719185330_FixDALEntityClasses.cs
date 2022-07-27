using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.DataLayer.Migrations
{
    public partial class FixDALEntityClasses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IventName",
                table: "ArtEvents",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "AmounOfTicket",
                table: "ArtEvents",
                newName: "AmountOfTickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "ArtEvents",
                newName: "IventName");

            migrationBuilder.RenameColumn(
                name: "AmountOfTickets",
                table: "ArtEvents",
                newName: "AmounOfTicket");
        }
    }
}
