using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedTickets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "Id", "PerformanceId", "Price", "SeatNumber", "UserId" },
                values: new object[,]
                {
                    { new Guid("5d07c7a8-7724-4e46-aa87-51a02178a865"), new Guid("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"), 35.00m, 21, null },
                    { new Guid("5d8a338d-bd09-4894-b045-641a65fd3a55"), new Guid("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"), 35.00m, 22, null },
                    { new Guid("7ca523d3-e6bb-4ea4-a97e-5a4d19c0bf99"), new Guid("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"), 25.00m, 2, null },
                    { new Guid("ca435dc3-7d25-420e-bd88-3d40062e80dd"), new Guid("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"), 30.00m, 12, null },
                    { new Guid("cf24e7cf-e4a3-41dd-bb75-4823c5bd95a2"), new Guid("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"), 25.00m, 3, null },
                    { new Guid("e17bed71-3daf-43b0-b4d3-0b96763f50b5"), new Guid("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"), 30.00m, 11, null },
                    { new Guid("f267c41d-03db-406b-8bcc-78ad094f4411"), new Guid("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"), 30.00m, 10, null },
                    { new Guid("f4a2b638-cc0d-4ff8-8053-5210453cecc4"), new Guid("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"), 25.00m, 1, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5d07c7a8-7724-4e46-aa87-51a02178a865"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("5d8a338d-bd09-4894-b045-641a65fd3a55"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("7ca523d3-e6bb-4ea4-a97e-5a4d19c0bf99"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("ca435dc3-7d25-420e-bd88-3d40062e80dd"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("cf24e7cf-e4a3-41dd-bb75-4823c5bd95a2"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("e17bed71-3daf-43b0-b4d3-0b96763f50b5"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f267c41d-03db-406b-8bcc-78ad094f4411"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "Id",
                keyValue: new Guid("f4a2b638-cc0d-4ff8-8053-5210453cecc4"));
        }
    }
}
