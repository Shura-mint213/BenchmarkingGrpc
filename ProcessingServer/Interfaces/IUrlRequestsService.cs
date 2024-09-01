namespace ProcessingServer.Interfaces
{
    public interface IUrlRequestsService
    {

        /// <summary>
        /// Метод осуществляет запрос к серверу за получением заказов.
        /// </summary>
        /// <remarks>Если при получении данных с сервера возникли ошибки, 
        /// то возвращается модель данных ошибок <seealso cref="ErrorModel"/>; 
        /// в противном случае возвращаются данные, которые пришли с сервера.</remarks>
        /// <returns>Список моделей данных заказов</returns>
        Task<string> GetOrdersToDataServer();

        /// <summary>
        /// Метод осуществляет запрос к серверу gRPC за получением заказов.
        /// </summary>
        /// <remarks>Если при получении данных с сервера возникли ошибки, 
        /// то возвращается модель данных ошибок <seealso cref="ErrorModel"/>; 
        /// в противном случае возвращаются данные, которые пришли с сервера.</remarks>
        /// <returns>Список моделей данных заказов</returns>
        Task<string> GetOrdersToGrpcServer();
    }
}
