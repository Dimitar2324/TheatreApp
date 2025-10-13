using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class PlayDeletableEntityAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plays",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Play identifier"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Play title"),
                    Author = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Play Author"),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false, comment: "Play Description"),
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false, comment: "Play Genre"),
                    Director = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Play Director"),
                    ScreenWriter = table.Column<string>(type: "nvarchar(800)", maxLength: 800, nullable: false, comment: "Play ScreenWriter"),
                    Duration = table.Column<int>(type: "int", nullable: false, comment: "Play Duration"),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: false, comment: "Play Release Date"),
                    ImageUrl = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true, comment: "Play Image URL"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false, comment: "Show whether the Play is deleted")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plays", x => x.Id);
                },
                comment: "Play in the system");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plays");
        }
    }
}
