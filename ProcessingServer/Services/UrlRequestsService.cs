using Google.Protobuf.WellKnownTypes;
using Grpc.Net.Client;
using GrpcTesting;
using GrpcTesting.Converters;
using Newtonsoft.Json;
using ProcessingServer.Interfaces;
using ProcessingServer.Shared.Statics;
using Shared.Models;
using Core.Parsers;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Google.Protobuf;
using Northwind.EntityModels;

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

        /// <summary>
        /// Метод осуществляет запрос к серверу gRPC за получением заказов.
        /// </summary>
        /// <remarks>Если при получении данных с сервера возникли ошибки, 
        /// то возвращается модель данных ошибок <seealso cref="ErrorModel"/>; 
        /// в противном случае возвращаются данные, которые пришли с сервера.</remarks>
        /// <returns>Список моделей данных заказов</returns>
        public async Task<string> GetOrdersToGrpcServer()
        {
            try
            {
                using (GrpcChannel channel =
                    GrpcChannel.ForAddress(SettingsHttpClients.GrpcTestingUrl))
                {
                    Orders.OrdersClient orders = new(channel);
                    OrdersReply reply = await orders.GetOrdersAsync(new Empty());
                    return JsonConvert.SerializeObject(reply.Orders.Select(order => order.ToOrderReplay()));
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении данных с сервера о заказах.", ex);
            }
        }
    }
}
