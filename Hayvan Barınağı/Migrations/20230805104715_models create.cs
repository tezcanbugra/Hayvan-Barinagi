using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Hayvan_Barınağı.Migrations
{
    /// <inheritdoc />
    public partial class modelscreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Turler",
                columns: table => new
                {
                    TurId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TurAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Turler", x => x.TurId);
                });

            migrationBuilder.CreateTable(
                name: "Cinsler",
                columns: table => new
                {
                    CinsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CinsAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TurId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cinsler", x => x.CinsId);
                    table.ForeignKey(
                        name: "FK_Cinsler_Turler_TurId",
                        column: x => x.TurId,
                        principalTable: "Turler",
                        principalColumn: "TurId");
                });

            migrationBuilder.CreateTable(
                name: "Hayvanlar",
                columns: table => new
                {
                    HayvanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CinsId = table.Column<int>(type: "int", nullable: true),
                    TurId = table.Column<int>(type: "int", nullable: true),
                    Yas = table.Column<int>(type: "int", nullable: false),
                    Cinsiyet = table.Column<bool>(type: "bit", nullable: false),
                    Sahiplenildi = table.Column<bool>(type: "bit", nullable: false),
                    Onay = table.Column<bool>(type: "bit", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EklenmeTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hayvanlar", x => x.HayvanId);
                    table.ForeignKey(
                        name: "FK_Hayvanlar_Cinsler_CinsId",
                        column: x => x.CinsId,
                        principalTable: "Cinsler",
                        principalColumn: "CinsId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Hayvanlar_Turler_TurId",
                        column: x => x.TurId,
                        principalTable: "Turler",
                        principalColumn: "TurId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cinsler_TurId",
                table: "Cinsler",
                column: "TurId");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_CinsId",
                table: "Hayvanlar",
                column: "CinsId");

            migrationBuilder.CreateIndex(
                name: "IX_Hayvanlar_TurId",
                table: "Hayvanlar",
                column: "TurId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hayvanlar");

            migrationBuilder.DropTable(
                name: "Cinsler");

            migrationBuilder.DropTable(
                name: "Turler");
        }
    }
}
