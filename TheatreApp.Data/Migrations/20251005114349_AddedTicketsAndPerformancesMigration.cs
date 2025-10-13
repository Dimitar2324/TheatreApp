using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTicketsAndPerformancesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Performances",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Performance identifier"),
                    PlayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the Play which will be performed"),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Shows start time of the performance"),
                    HallName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "The name of the hall in which the performance will be done"),
                    AvailableSeats = table.Column<int>(type: "int", nullable: false, defaultValue: 0, comment: "The count of the available seats for the performance"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows whether performance is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performances", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Performances_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Perfomance in the system");

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Ticket identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Ticket price"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false, comment: "SeatNumber in the theatre"),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the performance"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key to the user")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tickets_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Ticket in the system");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_PlayId",
                table: "Performances",
                column: "PlayId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PerformanceId",
                table: "Tickets",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "Performances");
        }
    }
}
