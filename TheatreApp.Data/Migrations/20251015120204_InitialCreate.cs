using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "UsersPlays",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the user"),
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

            migrationBuilder.CreateTable(
                name: "Tickets",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Ticket identifier"),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false, comment: "Ticket price"),
                    SeatNumber = table.Column<int>(type: "int", nullable: false, comment: "SeatNumber in the theatre"),
                    PerformanceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false, comment: "Foreign key to the performance"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true, comment: "Foreign key to the user"),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tickets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tickets_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Tickets_Performances_PerformanceId",
                        column: x => x.PerformanceId,
                        principalTable: "Performances",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Ticket in the system");

            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "Id", "Author", "Description", "Director", "Duration", "Genre", "ImageUrl", "ReleaseDate", "ScreenWriter", "Title" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "William Shakespeare", "A tragedy exploring revenge, betrayal, and madness as Prince Hamlet seeks justice for his father's murder.", "Laurence Olivier", 160, "Tragedy", "https://upload.wikimedia.org/wikipedia/commons/d/df/Hamlet.jpg", new DateOnly(1601, 1, 1), "Tom Stoppard", "Hamlet" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Victor Hugo", "A musical adaptation of Hugo's novel, portraying love, justice, and redemption during revolutionary France.", "Cameron Mackintosh", 180, "Musical", "https://media.londontheatredirect.com/Event/LesMiserables/event-hero-image_45974.png", new DateOnly(1980, 9, 24), "Claude-Michel Schönberg", "Les Miserables" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Henrik Ibsen", "A groundbreaking play exploring gender roles and individual freedom in 19th-century society.", "Joseph Losey", 135, "Drama", "https://m.media-amazon.com/images/I/61E1XsHuy-L._UF1000,1000_QL80_.jpg", new DateOnly(1879, 12, 21), "Christopher Hampton", "A Doll's House" },
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Samuel Beckett", "An absurdist play in which two men wait endlessly for someone who never arrives.", "Peter Hall", 140, "Absurdist", "https://www.hollywoodreporter.com/wp-content/uploads/2025/09/GODOT_AndyHenderson-3-H-2025.jpg?w=1296&h=730&crop=1", new DateOnly(1953, 1, 5), "Samuel Beckett", "Waiting for Godot" },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Arthur Miller", "A classic American tragedy about Willy Loman, a man destroyed by false dreams of success.", "Elia Kazan", 150, "Tragedy", "https://mediaproxy.tvtropes.org/width/1200/https://static.tvtropes.org/pmwiki/pub/images/death_of_a_salesman_1.JPG", new DateOnly(1949, 2, 10), "Arthur Miller", "Death of a Salesman" },
                    { new Guid("66666666-6666-6666-6666-666666666666"), "Gaston Leroux", "A haunting musical about love, obsession, and mystery beneath the Paris Opera House.", "Harold Prince", 175, "Musical", "https://assets.zyrosite.com/cdn-cgi/image/format=auto,w=375,h=501,fit=crop/YBgEp8nRLoCX8eJW/poto_s2_eventim_420_560_bg_sf-YZ92EQ6Rp5TMpRoj.jpg", new DateOnly(1986, 10, 9), "Andrew Lloyd Webber", "The Phantom of the Opera" }
                });

            migrationBuilder.InsertData(
                table: "Performances",
                columns: new[] { "Id", "AvailableSeats", "HallName", "PlayId", "StartTime" },
                values: new object[,]
                {
                    { new Guid("3c8e523e-29cd-4473-b4f3-74330c1d8dd1"), 120, "Main Hall", new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2025, 10, 15, 19, 30, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("6bd131b8-fe5d-415f-94d1-6f0ed0bc2dd4"), 200, "Grand Theatre", new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2025, 11, 2, 20, 0, 0, 0, DateTimeKind.Unspecified) },
                    { new Guid("a6321b71-7b6a-416e-a1bb-6ed0f2a5d37e"), 250, "Opera Hall", new Guid("66666666-6666-6666-6666-666666666666"), new DateTime(2025, 11, 15, 20, 0, 0, 0, DateTimeKind.Unspecified) }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_PlayId_StartTime",
                table: "Performances",
                columns: new[] { "PlayId", "StartTime" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_PerformanceId",
                table: "Tickets",
                column: "PerformanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_UserId",
                table: "Tickets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersPlays_PlayId",
                table: "UsersPlays",
                column: "PlayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UsersPlays");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Performances");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Plays");
        }
    }
}
