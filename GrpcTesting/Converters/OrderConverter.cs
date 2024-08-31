using Google.Protobuf.WellKnownTypes;
using Northwind.EntityModels;



namespace GrpcTesting.Converters
{
    public static class OrderConverter
    {
        /// <summary>
        /// Метод конвертации модели заказа в модель заказов protobuf
        /// </summary>
        /// <param name="order">Модель данных заказа</param>
        /// <returns>Модель данных заказа protobuf</returns>
        public static OrderReply ToApiOrder(this Order order)
        {
            OrderReply orderReplay = new()
            {
                OrderId = order.OrderId,
                OrderDate = order.OrderDate.ToString(),
                RequiredDate = order.OrderDate.ToString(),
                EmployeeId = order.EmployeeId,
                CustomerId = order.CustomerId,
                Freight = order.Freight.ToString(),
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipVia = order.ShipVia,
                ShipName = order.ShipName,
                ShipCountry = order.ShipCountry,
                ShippedDate = order.ShippedDate.ToString(),
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
            };

            return orderReplay;
        }
    }
}
