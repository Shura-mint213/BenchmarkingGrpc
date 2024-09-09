using Microsoft.Extensions.DependencyInjection;
using Repositories.MongoDB.Interfaces;

namespace Repositories.MongoDB.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositoriesMongo(this IServiceCollection services)
        {
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ICurrencyRepository, CurrencyRepository>();
        }
    }
}
