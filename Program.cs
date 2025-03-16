using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Serilog;
using MyAspNetApp.Infrastructure;
using MyAspNetApp.Domain;
using MyAspNetApp.Domain.Repositories.Abstract;
using MyAspNetApp.Domain.Repositories.EntityFramework;

namespace MyAspNetApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            // Serilog before`WebApplicationBuilder`
            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .WriteTo.File("Logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();

            Log.Information(" Pls prime...");

            var builder = WebApplication.CreateBuilder(args);

            // Serilog 
            builder.Host.UseSerilog((context, config) =>
            {
                config.ReadFrom.Configuration(context.Configuration);
            });

            //  appsettings.json
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .Build();

            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            // Database
            builder.Services.AddDbContext<AppDbContext>(x =>
                x.UseSqlServer(config.Database.ConnectionString));

            builder.Services.AddTransient<IServiceCategoriesRepository, EFServiceCategoriesRepository>();
            builder.Services.AddTransient<IServicesRepository, EFServicesRepository>();
            builder.Services.AddScoped<DataManager>();

            //  Identity
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // 6️⃣ Настройки аутентификации
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Подключаем логирование запросов
            app.UseSerilogRequestLogging();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            Log.Information("Cool!");


            var urls = app.Urls.Any() ? string.Join(", ", app.Urls) : "http://localhost:5127";
            Log.Information("{Urls}", urls);
            await app.RunAsync();
        }
    }
}
