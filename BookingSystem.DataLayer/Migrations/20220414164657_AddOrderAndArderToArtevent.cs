using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.DataLayer.Migrations
{
    public partial class AddOrderAndArderToArtevent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassicMusics_ArtEvent_Id",
                table: "ClassicMusics");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenAirs_ArtEvent_Id",
                table: "OpenAirs");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_ArtEvent_Id",
                table: "Parties");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtEvent",
                table: "ArtEvent");

            migrationBuilder.RenameTable(
                name: "ArtEvent",
                newName: "ArtEvents");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtEvents",
                table: "ArtEvents",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserEmail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TimeOfCreation = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderAndArtEvents",
                columns: table => new
                {
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ArtEventId = table.Column<int>(type: "int", nullable: false),
                    NumberOfBookedTicket = table.Column<int>(type: "int", nullable: false, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderAndArtEvents", x => new { x.OrderId, x.ArtEventId });
                    table.ForeignKey(
                        name: "FK_OrderAndArtEvents_ArtEvents_ArtEventId",
                        column: x => x.ArtEventId,
                        principalTable: "ArtEvents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderAndArtEvents_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderAndArtEvents_ArtEventId",
                table: "OrderAndArtEvents",
                column: "ArtEventId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderAndArtEvents_OrderId",
                table: "OrderAndArtEvents",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassicMusics_ArtEvents_Id",
                table: "ClassicMusics",
                column: "Id",
                principalTable: "ArtEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenAirs_ArtEvents_Id",
                table: "OpenAirs",
                column: "Id",
                principalTable: "ArtEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_ArtEvents_Id",
                table: "Parties",
                column: "Id",
                principalTable: "ArtEvents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClassicMusics_ArtEvents_Id",
                table: "ClassicMusics");

            migrationBuilder.DropForeignKey(
                name: "FK_OpenAirs_ArtEvents_Id",
                table: "OpenAirs");

            migrationBuilder.DropForeignKey(
                name: "FK_Parties_ArtEvents_Id",
                table: "Parties");

            migrationBuilder.DropTable(
                name: "OrderAndArtEvents");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ArtEvents",
                table: "ArtEvents");

            migrationBuilder.RenameTable(
                name: "ArtEvents",
                newName: "ArtEvent");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ArtEvent",
                table: "ArtEvent",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ClassicMusics_ArtEvent_Id",
                table: "ClassicMusics",
                column: "Id",
                principalTable: "ArtEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OpenAirs_ArtEvent_Id",
                table: "OpenAirs",
                column: "Id",
                principalTable: "ArtEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Parties_ArtEvent_Id",
                table: "Parties",
                column: "Id",
                principalTable: "ArtEvent",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
