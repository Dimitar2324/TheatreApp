using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDatabseWithPlays : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Plays",
                columns: new[] { "Id", "Author", "Description", "Director", "Duration", "Genre", "ImageUrl", "ReleaseDate", "ScreenWriter", "Title" },
                values: new object[,]
                {
                    { new Guid("5d01a4b3-2db2-4be6-a098-fd7d38dd6de1"), "William Shakespeare", "A tragedy exploring revenge, betrayal, and madness as Prince Hamlet seeks justice for his father's murder.", "Laurence Olivier", 160, "Tragedy", "https://upload.wikimedia.org/wikipedia/commons/d/df/Hamlet.jpg", new DateOnly(1601, 1, 1), "Tom Stoppard", "Hamlet" },
                    { new Guid("95c282d9-8b64-40c9-ac0d-deaa90b4da2a"), "Henrik Ibsen", "A groundbreaking play exploring gender roles and individual freedom in 19th-century society.", "Joseph Losey", 135, "Drama", "https://en.wikipedia.org/wiki/A_Doll%27s_House#/media/File:Adeleide_Johannessen_som_Nora_i_%22Et_dukkehjem%22,_Bergen_(11286565955).jpg", new DateOnly(1879, 12, 21), "Christopher Hampton", "A Doll's House" },
                    { new Guid("af514212-345b-4a51-80fd-7028fadc1556"), "Arthur Miller", "A classic American tragedy about Willy Loman, a man destroyed by false dreams of success.", "Elia Kazan", 150, "Tragedy", "https://en.wikipedia.org/wiki/Death_of_a_Salesman#/media/File:DeathOfASalesman.jpg", new DateOnly(1949, 2, 10), "Arthur Miller", "Death of a Salesman" },
                    { new Guid("bd26c148-1671-4895-8cbb-f2d3f058f62e"), "Gaston Leroux", "A haunting musical about love, obsession, and mystery beneath the Paris Opera House.", "Harold Prince", 175, "Musical", "https://en.wikipedia.org/wiki/The_Phantom_of_the_Opera_(1986_musical)#/media/File:The_Phantom_of_the_Opera_(1986_musical).jpg", new DateOnly(1986, 10, 9), "Andrew Lloyd Webber", "The Phantom of the Opera" },
                    { new Guid("f2e42036-03d4-4352-b708-08ac7c9af958"), "Victor Hugo", "A musical adaptation of Hugo's novel, portraying love, justice, and redemption during revolutionary France.", "Cameron Mackintosh", 180, "Musical", "https://en.wikipedia.org/wiki/Les_Mis%C3%A9rables#/media/File:Emile_Bayard_-_Cosette.jpg", new DateOnly(1980, 9, 24), "Claude-Michel Schönberg", "Les Miserables" },
                    { new Guid("f3753ad1-bd90-42d9-9b73-f6c99e860697"), "Samuel Beckett", "An absurdist play in which two men wait endlessly for someone who never arrives.", "Peter Hall", 140, "Absurdist", "https://en.wikipedia.org/wiki/Waiting_for_Godot#/media/File:En_attendant_Godot,_Festival_d'Avignon,_1978.jpeg", new DateOnly(1953, 1, 5), "Samuel Beckett", "Waiting for Godot" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("5d01a4b3-2db2-4be6-a098-fd7d38dd6de1"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("95c282d9-8b64-40c9-ac0d-deaa90b4da2a"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("af514212-345b-4a51-80fd-7028fadc1556"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("bd26c148-1671-4895-8cbb-f2d3f058f62e"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("f2e42036-03d4-4352-b708-08ac7c9af958"));

            migrationBuilder.DeleteData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("f3753ad1-bd90-42d9-9b73-f6c99e860697"));
        }
    }
}
