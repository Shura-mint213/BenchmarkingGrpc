using Microsoft.Extensions.DependencyInjection;
using Repositories.MsSql.Interfaces;
using Repositories.MsSql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repositories.Mongo.Interfaces;

namespace Repositories.Mongo.Extensions
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
