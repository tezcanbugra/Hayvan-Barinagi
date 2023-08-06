using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hayvan_Barınağı.Migrations
{
    /// <inheritdoc />
    public partial class hayvanfotografURLadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "fotografURL",
                table: "Hayvanlar",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "fotografURL",
                table: "Hayvanlar");
        }
    }
}
