﻿using Azure.Core;
using Grpc.Core;
using GrpcTesting.Converters;
using Northwind.EntityModels;

//using Northwind.EntityModels;
using Repositories.Interfaces;

namespace GrpcTesting.Services
{
    public class OrdersService : Orders.OrdersBase
    {
        private readonly IOrderRepository _orderRepository;
        public OrdersService(IOrderRepository orderRepository) 
        {
            _orderRepository = orderRepository;
        }

        public override async Task<OrdersReply> GetOrders(OrdersRequest request, ServerCallContext context)
        {
            var ordersReply = new OrdersReply();
            List<Order> orders = await _orderRepository.GetAsync();

            ordersReply.Orders.AddRange(orders.Select(order => order.ToApiOrder()));
            return ordersReply;
        }
    }
}
