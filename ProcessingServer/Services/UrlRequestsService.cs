using ProcessingServer.Interfaces;
using ProcessingServer.Shared.Statics;
using Shared.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ProcessingServer.Services
{
    public class UrlRequestsService : IUrlRequestsService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        /// <summary>
        /// URL-адрес сервера для получения данных
        /// </summary>
        private readonly string _dataServerUrl;
        /// <summary>
        /// Стандартная модель ошибок
        /// </summary>
        private readonly ErrorModel _standardErrorModel;
        public UrlRequestsService(IConfiguration conf,
            IHttpClientFactory httpClientFactory)
        {
            //_dataServerUrl = conf["DataServerUrl"] ??
            //    throw new ArgumentNullException(nameof(conf));
            _httpClientFactory = httpClientFactory ??
                throw new ArgumentNullException(nameof(httpClientFactory));
            _standardErrorModel =
                new ErrorModel("Ошибка сервера", "Возникла ошибка при получении данных с сервера");
        }

        /// <summary>
        /// Метод осуществляет запрос к серверу за получением заказов.
        /// </summary>
        /// <remarks>Если при получении данных с сервера возникли ошибки, 
        /// то возвращается модель данных ошибок <seealso cref="ErrorModel"/>; 
        /// в противном случае возвращаются данные, которые пришли с сервера.</remarks>
        /// <returns>Список моделей данных заказов</returns>
        public async Task<string> GetOrdersToDataServer()
        {
            using HttpClient client = _httpClientFactory
                .CreateClient(SettingsHttpClients.NameGrpcTesting);

            try
            {
                //using (GrpcChannel channel =
                //    GrpcChannel.ForAddress("https://localhost:5006"))
                //{
                //    Greeter.GreeterClient greeter = new(channel);
                //    HelloReply reply = await greeter.SayHelloAsync(new HelloRequest { Name = "Henrietta" });
                //    return "Greeting from gRPC service: " + reply.Message;
                //}
            }
            catch (Exception)
            {
                throw new Exception($"Northwind.gRPC service is not responding.");
            }

            HttpResponseMessage response =
                await client.GetAsync(_dataServerUrl);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return _standardErrorModel.ToString();
            }

        }
    }
}
