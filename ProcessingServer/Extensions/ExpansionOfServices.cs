using ProcessingServer.Shared.Statics;

namespace ProcessingServer.Extensions
{
    public static class ExpansionOfServices
    {
        public static void ConfigureHttpClientServices(this IServiceCollection services)
        {
            if (SettingsHttpClients.DataServerUrl is null)
                throw new ArgumentNullException(nameof(SettingsHttpClients.DataServerUrl));
            if (SettingsHttpClients.NameDataServer is null) 
                throw new ArgumentNullException(nameof(SettingsHttpClients.NameDataServer));

            if (SettingsHttpClients.NameGrpcTesting is null)
                throw new ArgumentNullException(nameof(SettingsHttpClients.NameGrpcTesting));
            if (SettingsHttpClients.GrpcTestingUrl is null)
                throw new ArgumentNullException(nameof(SettingsHttpClients.GrpcTestingUrl));

            TimeSpan timeout = TimeSpan.FromSeconds(30);

            services.AddHttpClient(SettingsHttpClients.NameDataServer, client =>
            {
                client.BaseAddress = new Uri(SettingsHttpClients.DataServerUrl);
                client.Timeout = timeout;
            });

            //services.AddHttpClient(SettingsHttpClients.NameGrpcTesting, client =>
            //{
            //    client.BaseAddress = new Uri(SettingsHttpClients.GrpcTestingUrl);
            //    client.Timeout = timeout;
            //});
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
        }
    }
}
