using BusinessLogic.Implimentation;
using BusinessLogic.Interfaces;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Model.Model;
using Model.Seed;

namespace Test.Configuration
{
    public static class ServiceExtensions
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IBookLoanService, BookLoanService>();
            services.AddTransient<IBookService, BookService>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
