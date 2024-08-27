using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Northwind.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Northwind.DataContext
{
    public static class NorthwindContextExtensions
    {
        public static IServiceCollection AddNorthwindContext(this IServiceCollection services,
            string connectionString)
        {
            services.AddDbContext<NorthwindContext>(option =>
                option.UseSqlServer(connectionString)
            );

            return services;
        }
    }
}
