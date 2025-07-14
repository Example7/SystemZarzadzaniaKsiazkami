using AppInterfaces.CMS;
using AppInterfaces.Sklep;
using AppServices.CMS;
using AppServices.Sklep;

namespace KlientApp
{
    public static class DependencyInjectionFactory
    {
        public static void Resolve(IServiceCollection services, IConfiguration conf)
        {
            services.AddScoped<IAktualnosciService, AktualnoscService>();
            services.AddScoped<ITrescStronyService, TrescStronyService>();
            services.AddScoped<IStronaService, StronaService>();
            services.AddScoped<IKategoriaService, KategoriaService>();
            services.AddScoped<IKsiazkiService, KsiazkiService>();
            services.AddScoped<IRecenzjeService, RecenzjeService>();
            services.AddScoped<IContentService, ContentService>();
            services.AddScoped<ISponsorService, SponsorService>();
            services.AddScoped<IFooterService, FooterService>();
            services.AddScoped<IONasService, ONasService>();
            services.AddScoped<IKontaktService, KontaktService>();
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IFaqService, FaqService>();
        }
    }
}
