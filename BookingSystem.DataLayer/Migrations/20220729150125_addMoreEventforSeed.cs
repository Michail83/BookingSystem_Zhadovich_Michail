using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookingSystem.DataLayer.Migrations
{
    public partial class addMoreEventforSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ArtEvents",
                columns: new[] { "Id", "AmountOfTickets", "Date", "EventName", "Latitude", "Longitude", "Place" },
                values: new object[,]
                {
                    { 7, 1997, new DateTime(2022, 11, 24, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 7 ", 53.90168316m, 27.57247554m, "Беларусь, Минск, место 7" },
                    { 32, 371, new DateTime(2022, 10, 11, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 32 ", 53.90077998m, 27.57125315m, "Беларусь, Минск, место 32" },
                    { 31, 1359, new DateTime(2022, 11, 21, 21, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 31 ", 53.90160242m, 27.57129287m, "Беларусь, Минск, место 31" },
                    { 30, 790, new DateTime(2022, 10, 29, 17, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 30 ", 53.90023471m, 27.57283559m, "Беларусь, Минск, место 30" },
                    { 29, 1180, new DateTime(2022, 10, 27, 16, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 29 ", 53.90201439m, 27.5728302m, "Беларусь, Минск, место 29" },
                    { 28, 852, new DateTime(2022, 8, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 28 ", 53.90034562m, 27.57170225m, "Беларусь, Минск, место 28" },
                    { 27, 1593, new DateTime(2022, 8, 14, 19, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 27 ", 53.90121721m, 27.57280758m, "Беларусь, Минск, место 27" },
                    { 26, 1354, new DateTime(2022, 8, 3, 21, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 26 ", 53.90183013m, 27.57041787m, "Беларусь, Минск, место 26" },
                    { 25, 1758, new DateTime(2022, 10, 21, 14, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 25 ", 53.90197521m, 27.57210964m, "Беларусь, Минск, место 25" },
                    { 24, 1850, new DateTime(2022, 11, 16, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 24 ", 53.90099403m, 27.57032045m, "Беларусь, Минск, место 24" },
                    { 23, 819, new DateTime(2022, 8, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 23 ", 53.90101991m, 27.57105763m, "Беларусь, Минск, место 23" },
                    { 22, 542, new DateTime(2022, 10, 17, 16, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 22 ", 53.90152881m, 27.57074823m, "Беларусь, Минск, место 22" },
                    { 21, 1463, new DateTime(2022, 9, 18, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 21 ", 53.90147207m, 27.57110328m, "Беларусь, Минск, место 21" },
                    { 20, 1382, new DateTime(2022, 9, 23, 21, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 20 ", 53.9020009m, 27.57266559m, "Беларусь, Минск, место 20" },
                    { 19, 934, new DateTime(2022, 10, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 19 ", 53.90173609m, 27.57259745m, "Беларусь, Минск, место 19" },
                    { 18, 16, new DateTime(2022, 8, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 18 ", 53.90128219m, 27.57000988m, "Беларусь, Минск, место 18" },
                    { 17, 132, new DateTime(2022, 11, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 17 ", 53.90129156m, 27.57118122m, "Беларусь, Минск, место 17" },
                    { 16, 468, new DateTime(2022, 9, 6, 18, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 16 ", 53.90023174m, 27.57132156m, "Беларусь, Минск, место 16" },
                    { 15, 1444, new DateTime(2022, 8, 6, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 15 ", 53.90170307m, 27.57023575m, "Беларусь, Минск, место 15" },
                    { 14, 1471, new DateTime(2022, 11, 17, 17, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 14 ", 53.90112879m, 27.57279098m, "Беларусь, Минск, место 14" },
                    { 13, 346, new DateTime(2022, 10, 25, 20, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 13 ", 53.90053316m, 27.57060408m, "Беларусь, Минск, место 13" },
                    { 12, 693, new DateTime(2022, 9, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 12 ", 53.90194404m, 27.5712736m, "Беларусь, Минск, место 12" },
                    { 11, 1655, new DateTime(2022, 9, 24, 18, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 11 ", 53.90010477m, 27.57260271m, "Беларусь, Минск, место 11" },
                    { 10, 803, new DateTime(2022, 9, 23, 17, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 10 ", 53.9018009m, 27.57071005m, "Беларусь, Минск, место 10" },
                    { 9, 63, new DateTime(2022, 11, 8, 20, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 9 ", 53.90153288m, 27.57091798m, "Беларусь, Минск, место 9" },
                    { 8, 1195, new DateTime(2022, 11, 14, 22, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 8 ", 53.90177102m, 27.57019996m, "Беларусь, Минск, место 8" },
                    { 33, 1788, new DateTime(2022, 9, 11, 18, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 33 ", 53.90167887m, 27.57107296m, "Беларусь, Минск, место 33" },
                    { 34, 300, new DateTime(2022, 11, 15, 13, 0, 0, 0, DateTimeKind.Unspecified), "Fake OpenAir № 34 ", 53.9015201m, 27.57097566m, "Беларусь, Минск, место 34" }
                });

            migrationBuilder.InsertData(
                table: "OpenAirs",
                columns: new[] { "Id", "HeadLiner" },
                values: new object[,]
                {
                    { 7, "Headliner - 7 " },
                    { 32, "Headliner - 32 " },
                    { 31, "Headliner - 31 " },
                    { 30, "Headliner - 30 " },
                    { 29, "Headliner - 29 " },
                    { 28, "Headliner - 28 " },
                    { 27, "Headliner - 27 " },
                    { 26, "Headliner - 26 " },
                    { 25, "Headliner - 25 " },
                    { 24, "Headliner - 24 " },
                    { 23, "Headliner - 23 " },
                    { 22, "Headliner - 22 " },
                    { 21, "Headliner - 21 " },
                    { 20, "Headliner - 20 " },
                    { 19, "Headliner - 19 " },
                    { 18, "Headliner - 18 " },
                    { 17, "Headliner - 17 " },
                    { 16, "Headliner - 16 " },
                    { 15, "Headliner - 15 " },
                    { 14, "Headliner - 14 " },
                    { 13, "Headliner - 13 " },
                    { 12, "Headliner - 12 " },
                    { 11, "Headliner - 11 " },
                    { 10, "Headliner - 10 " },
                    { 9, "Headliner - 9 " },
                    { 8, "Headliner - 8 " },
                    { 33, "Headliner - 33 " },
                    { 34, "Headliner - 34 " }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "OpenAirs",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "ArtEvents",
                keyColumn: "Id",
                keyValue: 34);
        }
    }
}
