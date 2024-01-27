using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FirstBlazorApp.Migrations
{
    /// <inheritdoc />
    public partial class Rename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageURL",
                table: "AnimeCards",
                newName: "ImageSource");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImageSource",
                table: "AnimeCards",
                newName: "ImageURL");
        }
    }
}
