using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppData.Migrations
{
    /// <inheritdoc />
    public partial class M2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImieNazwisko",
                table: "Autor");

            migrationBuilder.AddColumn<decimal>(
                name: "CenaJednostkowa",
                table: "ZamowienieKsiazka",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<string>(
                name: "AdresDostawy",
                table: "Zamowienie",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "KwotaCalkowita",
                table: "Zamowienie",
                type: "decimal(18,2)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Zamowienie",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Wydawnictwo",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Wydawnictwo",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Uzytkownik",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataRejestracji",
                table: "Uzytkownik",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "Tresc",
                table: "Recenzja",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "TypZnizki",
                table: "Kupon",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "Kupon",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "CzyAktywny",
                table: "Kupon",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Tytul",
                table: "Ksiazka",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Ksiazka",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataWydania",
                table: "Ksiazka",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OkladkaUrl",
                table: "Ksiazka",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Ksiazka",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Kategoria",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "Opis",
                table: "Kategoria",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "DaneKontaktowe",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Miasto",
                table: "DaneKontaktowe",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "DaneKontaktowe",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "DaneKontaktowe",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Imie",
                table: "Autor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nazwisko",
                table: "Autor",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "TrescStrony",
                columns: table => new
                {
                    TrescStronyID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Klucz = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Wartosc = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    DataModyfikacji = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KtoZmienil = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrescStrony", x => x.TrescStronyID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wydawnictwo_Nazwa",
                table: "Wydawnictwo",
                column: "Nazwa",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Uzytkownik_Email",
                table: "Uzytkownik",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrescStrony_Klucz",
                table: "TrescStrony",
                column: "Klucz",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TrescStrony");

            migrationBuilder.DropIndex(
                name: "IX_Wydawnictwo_Nazwa",
                table: "Wydawnictwo");

            migrationBuilder.DropIndex(
                name: "IX_Uzytkownik_Email",
                table: "Uzytkownik");

            migrationBuilder.DropColumn(
                name: "CenaJednostkowa",
                table: "ZamowienieKsiazka");

            migrationBuilder.DropColumn(
                name: "AdresDostawy",
                table: "Zamowienie");

            migrationBuilder.DropColumn(
                name: "KwotaCalkowita",
                table: "Zamowienie");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Zamowienie");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Wydawnictwo");

            migrationBuilder.DropColumn(
                name: "DataRejestracji",
                table: "Uzytkownik");

            migrationBuilder.DropColumn(
                name: "CzyAktywny",
                table: "Kupon");

            migrationBuilder.DropColumn(
                name: "DataWydania",
                table: "Ksiazka");

            migrationBuilder.DropColumn(
                name: "OkladkaUrl",
                table: "Ksiazka");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Ksiazka");

            migrationBuilder.DropColumn(
                name: "Opis",
                table: "Kategoria");

            migrationBuilder.DropColumn(
                name: "Imie",
                table: "Autor");

            migrationBuilder.DropColumn(
                name: "Nazwisko",
                table: "Autor");

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Wydawnictwo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Uzytkownik",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "Tresc",
                table: "Recenzja",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(1000)",
                oldMaxLength: 1000);

            migrationBuilder.AlterColumn<string>(
                name: "TypZnizki",
                table: "Kupon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Kod",
                table: "Kupon",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Tytul",
                table: "Ksiazka",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "ISBN",
                table: "Ksiazka",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "Nazwa",
                table: "Kategoria",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Telefon",
                table: "DaneKontaktowe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Miasto",
                table: "DaneKontaktowe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "KodPocztowy",
                table: "DaneKontaktowe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Adres",
                table: "DaneKontaktowe",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImieNazwisko",
                table: "Autor",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
