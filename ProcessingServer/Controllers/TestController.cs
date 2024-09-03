using Grpc.Net.Client;
using GrpcTesting;
using GrpcTesting.Converters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Northwind.EntityModels;
using ProcessingServer.Interfaces;
using ProcessingServer.Shared.Statics;
using System.Net.Http;

namespace ProcessingServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestController : ControllerBase
    {
        private readonly IUrlRequestsService _urlRequestsService;
        public TestController(IUrlRequestsService urlRequestsService)
        {
            _urlRequestsService = urlRequestsService ??
                throw new ArgumentNullException(nameof(urlRequestsService));
        }

        [Route("getOrdersServer")]
        [HttpGet]
        public async Task<string> GetData()
        {
            return await _urlRequestsService.GetOrdersToDataServer();
        }

        [Route("getOrdersGrpc")]
        [HttpGet]
        public async Task<string> GetOrders()
        {
            return await _urlRequestsService.GetOrdersToGrpcServer();
        }
    }
}
