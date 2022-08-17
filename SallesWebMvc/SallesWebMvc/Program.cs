using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SallesWebMvc.Data;

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
            builder.Services.AddScoped<SeedingService>();
            return builder.Services;
        }
    }
}