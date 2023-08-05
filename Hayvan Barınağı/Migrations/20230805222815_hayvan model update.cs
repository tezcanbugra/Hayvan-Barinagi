using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hayvan_Barınağı.Migrations
{
    /// <inheritdoc />
    public partial class hayvanmodelupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Cinsiyet",
                table: "Hayvanlar",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "bit");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "Cinsiyet",
                table: "Hayvanlar",
                type: "bit",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
