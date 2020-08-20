using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistence.Migrations
{
    public partial class InitialActivitySeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("8fcca202-d66f-4128-abd9-e8fcbec22c91"), "a", "London", new DateTime(2021, 4, 15, 15, 13, 53, 693, DateTimeKind.Local).AddTicks(3884), "Description", "Future Activity 8", "Cinema" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("066f3953-f4ba-480b-86ce-a69443b7eb3d"), "b", "London", new DateTime(2021, 4, 15, 15, 13, 53, 694, DateTimeKind.Local).AddTicks(3375), "Description", "Future Activity 8", "Cinema" });

            migrationBuilder.InsertData(
                table: "Activities",
                columns: new[] { "Id", "Category", "City", "Date", "Description", "Title", "Venue" },
                values: new object[] { new Guid("f87aaf0d-7362-441d-b951-4eff78225743"), "c", "London", new DateTime(2021, 4, 15, 15, 13, 53, 694, DateTimeKind.Local).AddTicks(3432), "Description", "Future Activity 8", "Cinema" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("066f3953-f4ba-480b-86ce-a69443b7eb3d"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("8fcca202-d66f-4128-abd9-e8fcbec22c91"));

            migrationBuilder.DeleteData(
                table: "Activities",
                keyColumn: "Id",
                keyValue: new Guid("f87aaf0d-7362-441d-b951-4eff78225743"));
        }
    }
}
