using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hayvan_Barınağı.Migrations
{
    /// <inheritdoc />
    public partial class hayvanupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HayvanAdi",
                table: "Hayvanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HayvanAdi",
                table: "Hayvanlar");
        }
    }
}
