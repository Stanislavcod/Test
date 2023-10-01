using Microsoft.AspNetCore.Authentication.Cookies;
using Model.DataBaseContext;

namespace Test.Configuration
{
    public static class ConfigurationService
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddApplicationDatabase(configuration);
            services.AddControllersWithViews();
            services.AddCustomServices();
            services.AddEndpointsApiExplorer();

           services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
     .AddCookie(options => options.LoginPath = "/login");
        }

        public static void Configure(WebApplication app, IServiceProvider serviceProvider)
        {
            if (!app.Environment.IsDevelopment())
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=User}/{action=Index}/{id?}");

            app.ConfigureDataSeeder();
        }
    }
}
