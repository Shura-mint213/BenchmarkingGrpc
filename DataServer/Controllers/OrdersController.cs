using Microsoft.AspNetCore.Mvc;
using Northwind.EntityModels;
using Repositories.Interfaces;

namespace DataServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [Route("getOrders")]
        [HttpGet]
        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _orderRepository.GetAsync();
        }

        [Route("getOrders/{skip:int}/{take:int}")]
        [HttpGet]
        public async Task<List<Order>> GetOrdersAsync(int skip = 0, int take = 10)
        {
            return await _orderRepository.GetAsync(skip, take);
        }
    }
}
