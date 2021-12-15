using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.DataLayer.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ArtEvent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AmounOfTicket = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Place = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtEvent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassicMusics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Voice = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcertName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassicMusics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClassicMusics_ArtEvent_Id",
                        column: x => x.Id,
                        principalTable: "ArtEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OpenAirs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HeadLiner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenAirs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenAirs_ArtEvent_Id",
                        column: x => x.Id,
                        principalTable: "ArtEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Parties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    AgeLimitation = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Parties_ArtEvent_Id",
                        column: x => x.Id,
                        principalTable: "ArtEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "ArtEvent",
                columns: new[] { "Id", "AmounOfTicket", "Date", "IventName", "Place" },
                values: new object[,]
                {
                    { 4, 200, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "music1", "unknown" },
                    { 5, 200, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "music2", "unknown" },
                    { 2, 2000, new DateTime(2021, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "BeerFest", "stillInReserch" },
                    { 3, 9000, new DateTime(2021, 12, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "BeeeerFast", "stillInReserchToo" },
                    { 6, 100, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "SuperParty", "InResearch" },
                    { 1, 10, new DateTime(2021, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), "MegaParty", "InResearchToo" }
                });

            migrationBuilder.InsertData(
                table: "ClassicMusics",
                columns: new[] { "Id", "ConcertName", "Voice" },
                values: new object[,]
                {
                    { 4, "Bah", "tenor" },
                    { 5, "Babah", "bas" }
                });

            migrationBuilder.InsertData(
                table: "OpenAirs",
                columns: new[] { "Id", "HeadLiner" },
                values: new object[,]
                {
                    { 2, "aassddffgg" },
                    { 3, "ggffddssaa" }
                });

            migrationBuilder.InsertData(
                table: "Parties",
                columns: new[] { "Id", "AgeLimitation" },
                values: new object[,]
                {
                    { 6, 18 },
                    { 1, 21 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassicMusics");

            migrationBuilder.DropTable(
                name: "OpenAirs");

            migrationBuilder.DropTable(
                name: "Parties");

            migrationBuilder.DropTable(
                name: "ArtEvent");
        }
    }
}
