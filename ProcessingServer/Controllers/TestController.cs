using Grpc.Net.Client;
using GrpcTesting;
using GrpcTesting.Converters;
using GrpcTestingClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Northwind.EntityModels;
using ProcessingServer.Shared.Statics;

namespace ProcessingServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        [Route("getData")]
        [HttpGet]
        public async Task<string> GetData()
        {
            try
            {
                using (GrpcChannel channel =
                    GrpcChannel.ForAddress("https://localhost:5006"))
                {
                    Greeter.GreeterClient greeter = new(channel);
                    HelloReply reply = await greeter.SayHelloAsync(new HelloRequest { Name = "Henrietta" });
                    return "Greeting from gRPC service: " + reply.Message;
                }
            }
            catch (Exception)
            {
                throw new Exception($"Northwind.gRPC service is not responding.");
            }
        }

        [Route("getOrders")]
        [HttpGet]
        public async Task<IEnumerable<Order>> GetOrders()
        {
            try
            {
                using (GrpcChannel channel =
                    GrpcChannel.ForAddress(SettingsHttpClients.GrpcTestingUrl))
                {
                    Orders.OrdersClient orders = new(channel);
                    orders.GetOrders(new OrdersRequest());
                    OrdersReply reply = await orders.GetOrdersAsync(new OrdersRequest());
                    return reply.Orders.Select(order => order.ToOrderReplay());
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении данных с сервера о заказах.", ex);
            }
        }
    }
}
