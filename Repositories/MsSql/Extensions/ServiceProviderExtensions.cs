using Microsoft.Extensions.DependencyInjection;
using Repositories.MSSQL.Interfaces;

namespace Repositories.MSSQL.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositoriesMSSQL(this IServiceCollection services)
        {
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
        }
    }
}
