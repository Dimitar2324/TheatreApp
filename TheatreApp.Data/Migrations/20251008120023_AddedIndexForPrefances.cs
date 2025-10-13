using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheatreApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedIndexForPrefances : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Performances_PlayId",
                table: "Performances");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ImageUrl",
                value: "https://media.londontheatredirect.com/Event/LesMiserables/event-hero-image_45974.png");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "ImageUrl",
                value: "https://m.media-amazon.com/images/I/61E1XsHuy-L._UF1000,1000_QL80_.jpg");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "ImageUrl",
                value: "https://www.hollywoodreporter.com/wp-content/uploads/2025/09/GODOT_AndyHenderson-3-H-2025.jpg?w=1296&h=730&crop=1");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "ImageUrl",
                value: "https://mediaproxy.tvtropes.org/width/1200/https://static.tvtropes.org/pmwiki/pub/images/death_of_a_salesman_1.JPG");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "ImageUrl",
                value: "https://assets.zyrosite.com/cdn-cgi/image/format=auto,w=375,h=501,fit=crop/YBgEp8nRLoCX8eJW/poto_s2_eventim_420_560_bg_sf-YZ92EQ6Rp5TMpRoj.jpg");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_PlayId_StartTime",
                table: "Performances",
                columns: new[] { "PlayId", "StartTime" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Performances_PlayId_StartTime",
                table: "Performances");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"),
                column: "ImageUrl",
                value: "https://en.wikipedia.org/wiki/Les_Mis%C3%A9rables#/media/File:Emile_Bayard_-_Cosette.jpg");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"),
                column: "ImageUrl",
                value: "https://en.wikipedia.org/wiki/A_Doll%27s_House#/media/File:Adeleide_Johannessen_som_Nora_i_%22Et_dukkehjem%22,_Bergen_(11286565955).jpg");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"),
                column: "ImageUrl",
                value: "https://en.wikipedia.org/wiki/Waiting_for_Godot#/media/File:En_attendant_Godot,_Festival_d'Avignon,_1978.jpeg");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"),
                column: "ImageUrl",
                value: "https://en.wikipedia.org/wiki/Death_of_a_Salesman#/media/File:DeathOfASalesman.jpg");

            migrationBuilder.UpdateData(
                table: "Plays",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"),
                column: "ImageUrl",
                value: "https://en.wikipedia.org/wiki/The_Phantom_of_the_Opera_(1986_musical)#/media/File:The_Phantom_of_the_Opera_(1986_musical).jpg");

            migrationBuilder.CreateIndex(
                name: "IX_Performances_PlayId",
                table: "Performances",
                column: "PlayId");
        }
    }
}
