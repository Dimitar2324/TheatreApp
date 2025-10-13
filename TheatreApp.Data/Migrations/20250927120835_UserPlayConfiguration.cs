using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserPlayConfiguration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UsersPlays",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false, comment: "Foreign key to the user"),
                    PlayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the play"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Shows whether UserPlay entry is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersPlays", x => new { x.UserId, x.PlayId });
                    table.ForeignKey(
                        name: "FK_UsersPlays_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersPlays_Plays_PlayId",
                        column: x => x.PlayId,
                        principalTable: "Plays",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "User's favourites entry in the system");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlays_PlayId",
                table: "UsersPlays",
                column: "PlayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersPlays");
        }
    }
}
