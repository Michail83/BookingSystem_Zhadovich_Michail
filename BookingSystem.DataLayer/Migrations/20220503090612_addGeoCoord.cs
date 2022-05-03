using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.DataLayer.Migrations
{
    public partial class addGeoCoord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Latitude",
                table: "ArtEvents",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Longitude",
                table: "ArtEvents",
                type: "decimal(9,6)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "IventName", "Latitude", "Longitude", "Place" },
                values: new object[] { new DateTime(2022, 7, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), "Fake classic musik  1", 53.91486434449279m, 27.584181354972173m, "Беларусь, Минск, проспект Независимости, 50" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Latitude", "Longitude", "Place" },
                values: new object[] { 250, new DateTime(2022, 8, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "Fake classic musik  2", 53.91486434449279m, 27.584181354972173m, "Беларусь, Минск, проспект Независимости, 50" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Latitude", "Longitude", "Place" },
                values: new object[] { 100, new DateTime(2022, 7, 25, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fake Avia Party", 53.96147426906447m, 27.65091340326826m, "Беларусь, Минский район, Боровлянский сельсовет, деревня Копище" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Latitude", "Longitude", "Place" },
                values: new object[] { 1500, new DateTime(2022, 12, 31, 15, 0, 0, 0, DateTimeKind.Unspecified), "Fake Gorky Party", 53.90222207800099m, 27.57284678552759m, "Беларусь, Минск, Первомайская улица, 3А" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Latitude", "Longitude", "Place" },
                values: new object[] { 300, new DateTime(2022, 9, 25, 22, 0, 0, 0, DateTimeKind.Unspecified), " Fake Макс party", 53.92206511236228m, 27.59704956223782m, "Беларусь, Минск, проспект Независимости, 73" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Latitude", "Longitude", "Place" },
                values: new object[] { 1500, new DateTime(2022, 10, 31, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fake TNT Party", 53.902375271214524m, 27.55158689814755m, "Беларусь, Минск, Революционная улица, 9А" });

            migrationBuilder.UpdateData(
                table: "ClassicMusics",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcertName",
                value: "classic musik  1");

            migrationBuilder.UpdateData(
                table: "ClassicMusics",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcertName",
                value: "classic musik  2");

            migrationBuilder.UpdateData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeadLiner",
                value: "The Best Headliner2");

            migrationBuilder.UpdateData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 3,
                column: "HeadLiner",
                value: "The Best Headliner");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ArtEvents");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ArtEvents");

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Date", "IventName", "Place" },
                values: new object[] { new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "music1", "unknown" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Place" },
                values: new object[] { 200, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "music2", "unknown" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Place" },
                values: new object[] { 2000, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "BeerFest", "stillInReserch" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Place" },
                values: new object[] { 9000, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "BeeeerFast", "stillInReserchToo" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Place" },
                values: new object[] { 10, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "MegaParty", "InResearchToo" });

            migrationBuilder.UpdateData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "AmounOfTicket", "Date", "IventName", "Place" },
                values: new object[] { 100, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperParty", "InResearch" });

            migrationBuilder.UpdateData(
                table: "ClassicMusics",
                keyColumn: "Id",
                keyValue: 4,
                column: "ConcertName",
                value: "Bah");

            migrationBuilder.UpdateData(
                table: "ClassicMusics",
                keyColumn: "Id",
                keyValue: 5,
                column: "ConcertName",
                value: "Babah");

            migrationBuilder.UpdateData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 2,
                column: "HeadLiner",
                value: "aassddffgg");

            migrationBuilder.UpdateData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 3,
                column: "HeadLiner",
                value: "ggffddssaa");
        }
    }
}
