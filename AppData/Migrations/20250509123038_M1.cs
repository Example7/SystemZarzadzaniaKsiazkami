#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace AppData.Migrations
{
    /// <inheritdoc />
    public partial class M1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktualnosc",
                columns: table => new
                {
                    IdAktualnosci = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktualnosc", x => x.IdAktualnosci);
                });

            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    AutorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImieNazwisko = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.AutorID);
                });

            migrationBuilder.CreateTable(
                name: "Kategoria",
                columns: table => new
                {
                    KategoriaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategoria", x => x.KategoriaID);
                });

            migrationBuilder.CreateTable(
                name: "Kupon",
                columns: table => new
                {
                    KuponID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypZnizki = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WartoscZnizki = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    DataWaznosci = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MinimalnaWartosc = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupon", x => x.KuponID);
                });

            migrationBuilder.CreateTable(
                name: "Strona",
                columns: table => new
                {
                    IdStrony = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LinkTytul = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tytul = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    Pozycja = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Strona", x => x.IdStrony);
                });

            migrationBuilder.CreateTable(
                name: "Uzytkownik",
                columns: table => new
                {
                    UzytkownikID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HasloHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Imie = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Nazwisko = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CzyAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uzytkownik", x => x.UzytkownikID);
                });

            migrationBuilder.CreateTable(
                name: "Wydawnictwo",
                columns: table => new
                {
                    WydawnictwoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nazwa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wydawnictwo", x => x.WydawnictwoID);
                });

            migrationBuilder.CreateTable(
                name: "DaneKontaktowe",
                columns: table => new
                {
                    UzytkownikID = table.Column<int>(type: "int", nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KodPocztowy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miasto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DaneKontaktowe", x => x.UzytkownikID);
                    table.ForeignKey(
                        name: "FK_DaneKontaktowe_Uzytkownik_UzytkownikID",
                        column: x => x.UzytkownikID,
                        principalTable: "Uzytkownik",
                        principalColumn: "UzytkownikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Zamowienie",
                columns: table => new
                {
                    ZamowienieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataZamowienia = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UzytkownikID = table.Column<int>(type: "int", nullable: false),
                    KuponID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zamowienie", x => x.ZamowienieID);
                    table.ForeignKey(
                        name: "FK_Zamowienie_Kupon_KuponID",
                        column: x => x.KuponID,
                        principalTable: "Kupon",
                        principalColumn: "KuponID");
                    table.ForeignKey(
                        name: "FK_Zamowienie_Uzytkownik_UzytkownikID",
                        column: x => x.UzytkownikID,
                        principalTable: "Uzytkownik",
                        principalColumn: "UzytkownikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ksiazka",
                columns: table => new
                {
                    KsiazkaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tytul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ISBN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    AutorID = table.Column<int>(type: "int", nullable: false),
                    WydawnictwoID = table.Column<int>(type: "int", nullable: false),
                    KategoriaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ksiazka", x => x.KsiazkaID);
                    table.ForeignKey(
                        name: "FK_Ksiazka_Autor_AutorID",
                        column: x => x.AutorID,
                        principalTable: "Autor",
                        principalColumn: "AutorID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazka_Kategoria_KategoriaID",
                        column: x => x.KategoriaID,
                        principalTable: "Kategoria",
                        principalColumn: "KategoriaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ksiazka_Wydawnictwo_WydawnictwoID",
                        column: x => x.WydawnictwoID,
                        principalTable: "Wydawnictwo",
                        principalColumn: "WydawnictwoID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Recenzja",
                columns: table => new
                {
                    RecenzjaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ocena = table.Column<int>(type: "int", nullable: false),
                    Tresc = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataDodania = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KsiazkaID = table.Column<int>(type: "int", nullable: false),
                    UzytkownikID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recenzja", x => x.RecenzjaID);
                    table.ForeignKey(
                        name: "FK_Recenzja_Ksiazka_KsiazkaID",
                        column: x => x.KsiazkaID,
                        principalTable: "Ksiazka",
                        principalColumn: "KsiazkaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Recenzja_Uzytkownik_UzytkownikID",
                        column: x => x.UzytkownikID,
                        principalTable: "Uzytkownik",
                        principalColumn: "UzytkownikID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ZamowienieKsiazka",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZamowienieID = table.Column<int>(type: "int", nullable: false),
                    KsiazkaID = table.Column<int>(type: "int", nullable: false),
                    Ilosc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ZamowienieKsiazka", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ZamowienieKsiazka_Ksiazka_KsiazkaID",
                        column: x => x.KsiazkaID,
                        principalTable: "Ksiazka",
                        principalColumn: "KsiazkaID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ZamowienieKsiazka_Zamowienie_ZamowienieID",
                        column: x => x.ZamowienieID,
                        principalTable: "Zamowienie",
                        principalColumn: "ZamowienieID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_AutorID",
                table: "Ksiazka",
                column: "AutorID");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_KategoriaID",
                table: "Ksiazka",
                column: "KategoriaID");

            migrationBuilder.CreateIndex(
                name: "IX_Ksiazka_WydawnictwoID",
                table: "Ksiazka",
                column: "WydawnictwoID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzja_KsiazkaID",
                table: "Recenzja",
                column: "KsiazkaID");

            migrationBuilder.CreateIndex(
                name: "IX_Recenzja_UzytkownikID",
                table: "Recenzja",
                column: "UzytkownikID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_KuponID",
                table: "Zamowienie",
                column: "KuponID");

            migrationBuilder.CreateIndex(
                name: "IX_Zamowienie_UzytkownikID",
                table: "Zamowienie",
                column: "UzytkownikID");

            migrationBuilder.CreateIndex(
                name: "IX_ZamowienieKsiazka_KsiazkaID",
                table: "ZamowienieKsiazka",
                column: "KsiazkaID");

            migrationBuilder.CreateIndex(
                name: "IX_ZamowienieKsiazka_ZamowienieID",
                table: "ZamowienieKsiazka",
                column: "ZamowienieID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aktualnosc");

            migrationBuilder.DropTable(
                name: "DaneKontaktowe");

            migrationBuilder.DropTable(
                name: "Recenzja");

            migrationBuilder.DropTable(
                name: "Strona");

            migrationBuilder.DropTable(
                name: "ZamowienieKsiazka");

            migrationBuilder.DropTable(
                name: "Ksiazka");

            migrationBuilder.DropTable(
                name: "Zamowienie");

            migrationBuilder.DropTable(
                name: "Autor");

            migrationBuilder.DropTable(
                name: "Kategoria");

            migrationBuilder.DropTable(
                name: "Wydawnictwo");

            migrationBuilder.DropTable(
                name: "Kupon");

            migrationBuilder.DropTable(
                name: "Uzytkownik");
        }
    }
}
