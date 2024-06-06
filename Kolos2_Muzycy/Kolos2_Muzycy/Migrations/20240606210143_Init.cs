using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Kolos2_Muzycy.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Muzyk",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Imie = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Nazwisko = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Pseudonim = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdMuzyk", x => x.IdMuzyk);
                });

            migrationBuilder.CreateTable(
                name: "Wytwornia",
                columns: table => new
                {
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdWytwornia", x => x.IdWytwornia);
                });

            migrationBuilder.CreateTable(
                name: "Album",
                columns: table => new
                {
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaAlbumu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    DataWydania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdWytwornia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdAlbum", x => x.IdAlbum);
                    table.ForeignKey(
                        name: "FK_Album_Wytwornia_IdWytwornia",
                        column: x => x.IdWytwornia,
                        principalTable: "Wytwornia",
                        principalColumn: "IdWytwornia",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Utwor",
                columns: table => new
                {
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NazwaUtworu = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    CzasTrwania = table.Column<float>(type: "real", nullable: false),
                    IdAlbum = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("IdUtwor", x => x.IdUtwor);
                    table.ForeignKey(
                        name: "FK_Utwor_Album_IdUtwor",
                        column: x => x.IdUtwor,
                        principalTable: "Album",
                        principalColumn: "IdAlbum",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "WykonawcaUtworu",
                columns: table => new
                {
                    IdMuzyk = table.Column<int>(type: "int", nullable: false),
                    IdUtwor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WykonawcaUtworu", x => new { x.IdMuzyk, x.IdUtwor });
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Muzyk_IdMuzyk",
                        column: x => x.IdMuzyk,
                        principalTable: "Muzyk",
                        principalColumn: "IdMuzyk",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WykonawcaUtworu_Utwor_IdUtwor",
                        column: x => x.IdUtwor,
                        principalTable: "Utwor",
                        principalColumn: "IdUtwor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Muzyk",
                columns: new[] { "IdMuzyk", "Imie", "Nazwisko", "Pseudonim" },
                values: new object[,]
                {
                    { 1, "Adam", "Nowak", "Adasio200" },
                    { 2, "Adrianna", "Malinowska", null }
                });

            migrationBuilder.InsertData(
                table: "Wytwornia",
                columns: new[] { "IdWytwornia", "Nazwa" },
                values: new object[,]
                {
                    { 1, "Jasie" },
                    { 2, "Muchy" }
                });

            migrationBuilder.InsertData(
                table: "Album",
                columns: new[] { "IdAlbum", "DataWydania", "IdWytwornia", "NazwaAlbumu" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 6, 6, 0, 0, 0, 0, DateTimeKind.Local), 1, "album1" },
                    { 2, new DateTime(2024, 6, 16, 0, 0, 0, 0, DateTimeKind.Local), 1, "album2" },
                    { 3, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Local), 2, "album3" }
                });

            migrationBuilder.InsertData(
                table: "Utwor",
                columns: new[] { "IdUtwor", "CzasTrwania", "IdAlbum", "NazwaUtworu" },
                values: new object[,]
                {
                    { 1, 2.2f, 1, "al1na1" },
                    { 2, 3.3f, 1, "al1na2" },
                    { 3, 5.5f, 2, "al12na1" }
                });

            migrationBuilder.InsertData(
                table: "WykonawcaUtworu",
                columns: new[] { "IdMuzyk", "IdUtwor" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 1 },
                    { 2, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Album_IdWytwornia",
                table: "Album",
                column: "IdWytwornia");

            migrationBuilder.CreateIndex(
                name: "IX_WykonawcaUtworu_IdUtwor",
                table: "WykonawcaUtworu",
                column: "IdUtwor");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WykonawcaUtworu");

            migrationBuilder.DropTable(
                name: "Muzyk");

            migrationBuilder.DropTable(
                name: "Utwor");

            migrationBuilder.DropTable(
                name: "Album");

            migrationBuilder.DropTable(
                name: "Wytwornia");
        }
    }
}
