using Microsoft.Extensions.DependencyInjection;
using Repositories.MsSql.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.MsSql.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void AddRepositoriesMsSql(this IServiceCollection services)
        {
            services.AddTransient<IOrderRepository, OrderRepository>();
        }
    }
}
