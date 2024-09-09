using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dictionary.MSSQLContext
{
    public static class DictionaryContextExtensions
    {
        public static IServiceCollection AddDictionaryContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<DictionaryContext>(option =>
                option.UseSqlServer(connectionString)
            );

            return services;
        }
    }
}
