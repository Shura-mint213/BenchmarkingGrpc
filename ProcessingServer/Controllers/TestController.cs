using Grpc.Net.Client;
using GrpcTestingClient;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Northwind.EntityModels;

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
        public async Task<IActionResult> GetOrders()
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                throw new Exception("Ошибка при получении данных с сервера о заказах.", ex);
            }
        }
    }
}
