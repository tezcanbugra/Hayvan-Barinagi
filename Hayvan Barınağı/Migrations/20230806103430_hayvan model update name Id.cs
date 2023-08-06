using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hayvan_Barınağı.Migrations
{
    /// <inheritdoc />
    public partial class hayvanmodelupdatenameId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hayvanlar_Cinsler_CinsId",
                table: "Hayvanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hayvanlar_Turler_TurId",
                table: "Hayvanlar");

            migrationBuilder.AlterColumn<Guid>(
                name: "TurId",
                table: "Hayvanlar",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "CinsId",
                table: "Hayvanlar",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CinsAdi",
                table: "Hayvanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TurAdi",
                table: "Hayvanlar",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Hayvanlar_Cinsler_CinsId",
                table: "Hayvanlar",
                column: "CinsId",
                principalTable: "Cinsler",
                principalColumn: "CinsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Hayvanlar_Turler_TurId",
                table: "Hayvanlar",
                column: "TurId",
                principalTable: "Turler",
                principalColumn: "TurId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hayvanlar_Cinsler_CinsId",
                table: "Hayvanlar");

            migrationBuilder.DropForeignKey(
                name: "FK_Hayvanlar_Turler_TurId",
                table: "Hayvanlar");

            migrationBuilder.DropColumn(
                name: "CinsAdi",
                table: "Hayvanlar");

            migrationBuilder.DropColumn(
                name: "TurAdi",
                table: "Hayvanlar");

            migrationBuilder.AlterColumn<Guid>(
                name: "TurId",
                table: "Hayvanlar",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<Guid>(
                name: "CinsId",
                table: "Hayvanlar",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Hayvanlar_Cinsler_CinsId",
                table: "Hayvanlar",
                column: "CinsId",
                principalTable: "Cinsler",
                principalColumn: "CinsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hayvanlar_Turler_TurId",
                table: "Hayvanlar",
                column: "TurId",
                principalTable: "Turler",
                principalColumn: "TurId");
        }
    }
}
