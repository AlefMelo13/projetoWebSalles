using Microsoft.EntityFrameworkCore;
using SallesWebMvc.Data;
using SallesWebMvc.Services;
using System.Globalization;
using Microsoft.AspNetCore.Localization;

namespace SallesWebMvc
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.ConfigurarMySql();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                SeedingService.Seed(services);
            }

            //Localização padrão da aplicação
            var ptBr = new CultureInfo("pt-Br");
            var localizationOpition = new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture(ptBr),
                SupportedCultures = new List<CultureInfo> { ptBr },
                SupportedUICultures = new List<CultureInfo> { ptBr },
            };

            app.UseRequestLocalization(localizationOpition);

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }

    public static class MinhaClasseDeConfiguracao
    {
        public static IServiceCollection ConfigurarMySql(this WebApplicationBuilder builder)
        {
            string connectionString = builder.Configuration.GetConnectionString("SallesWebMvcContext") ?? throw new InvalidOperationException("Connection string 'SallesWebMvcContext' not found.");

            builder.Services.AddDbContext<SallesWebMvcContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                );
            builder.Services.AddScoped<SellerService>();
            builder.Services.AddScoped<DepartmentService>();
            builder.Services.AddScoped<SallesRecordService>();
            builder.Services.AddScoped<ProdutoService>();
            builder.Services.AddScoped<MarcaService>();
            return builder.Services;
        }
    }
}