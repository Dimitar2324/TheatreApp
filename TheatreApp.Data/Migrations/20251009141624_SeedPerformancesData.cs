using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedPerformancesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "Id", "AvailableSeats", "HallName", "PlayId", "StartTime" },
                values: new object[,]
                {
                    { new Guid("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"), 120, "Main Hall", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 15, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"), 200, "Grand Theatre", new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 11, 2, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"), 250, "Opera Hall", new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: new Guid("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"));

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: new Guid("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"));

            migrationBuilder.DeleteData(
                table: "Performances",
                keyColumn: "Id",
                keyValue: new Guid("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"));
        }
    }
}
