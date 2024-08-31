using Google.Protobuf.WellKnownTypes;
using Northwind.EntityModels;



namespace GrpcTesting.Converters
{
    public static class OrderConverter
    {
        /// <summary>
        /// Метод конвертации модели данных protobuf в модель данных заказа 
        /// </summary>
        /// <param name="orderReply">Модель данных protobuf заказа</param>
        /// <returns>Модель данных заказа</returns>
        public static Order ToOrderReplay(this OrderReply orderReply)
        {
            Order order = new();

            order.OrderId = orderReply.OrderId;
            order.ShipCity = orderReply.ShipCity;
            order.ShipVia = orderReply.ShipVia;
            order.ShipName = orderReply.ShipName;
            order.ShipCountry = orderReply.ShipCountry;
            order.CustomerId = orderReply.CustomerId;
            order.EmployeeId = orderReply.EmployeeId;
            order.ShipPostalCode = orderReply.ShipPostalCode;
            order.ShipAddress = orderReply.ShipAddress;
            order.ShipRegion = orderReply.ShipRegion;
            if (decimal.TryParse(orderReply.Freight, out decimal freight))
                order.Freight = freight;
            if (DateTime.TryParse(orderReply.OrderDate, out DateTime orderDate))
                order.OrderDate = orderDate;
            if (DateTime.TryParse(orderReply.OrderDate, out DateTime requiredDate))
                order.RequiredDate = requiredDate;
            if (DateTime.TryParse(orderReply.OrderDate, out DateTime shippedDate))
                order.ShippedDate = shippedDate;

            return order;
        }
    }
}
