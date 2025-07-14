using AppData.Data.CMS;
using AppData.Data.Sklep;
using Microsoft.EntityFrameworkCore;

namespace AppData.Data
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options)
            : base(options)
        {
        }

        public DbSet<Aktualnosc> Aktualnosc { get; set; } = default!;
        public DbSet<Strona> Strona { get; set; } = default!;
        public DbSet<Autor> Autor { get; set; } = default!;
        public DbSet<DaneKontaktowe> DaneKontaktowe { get; set; } = default!;
        public DbSet<Kategoria> Kategoria { get; set; } = default!;
        public DbSet<Ksiazka> Ksiazka { get; set; } = default!;
        public DbSet<Kupon> Kupon { get; set; } = default!;
        public DbSet<Recenzja> Recenzja { get; set; } = default!;
        public DbSet<Uzytkownik> Uzytkownik { get; set; } = default!;
        public DbSet<Wydawnictwo> Wydawnictwo { get; set; } = default!;
        public DbSet<Zamowienie> Zamowienie { get; set; } = default!;
        public DbSet<ZamowienieKsiazka> ZamowienieKsiazka { get; set; } = default!;
        public DbSet<TrescStrony> TrescStrony { get; set; } = default!;
        public DbSet<Sponsor> Sponsor { get; set; } = default!;
        public DbSet<FooterItem> FooterItem { get; set; } = default!;
    }
}
