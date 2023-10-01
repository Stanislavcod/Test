using Model.DataBaseContext;
using Model.Seed;

namespace Test.Configuration
{
    public static class ConfigurationDataSeeder
    {
        public static void ConfigureDataSeeder(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var serviceProvider = scope.ServiceProvider;
                var context = serviceProvider.GetRequiredService<ApplicationDataBaseContext>();
                var dataSeeder = new DataSeeder(context);
                dataSeeder.Initialize();
            }
        }
    }
}
