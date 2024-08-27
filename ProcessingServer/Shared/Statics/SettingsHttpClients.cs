namespace ProcessingServer.Shared.Statics
{
    /// <summary>
    /// Название настройки для разных серверов http клиентов
    /// </summary>
    public static class SettingsHttpClients
    {
        /// <summary>
        /// Название клиента для получения данных
        /// </summary>
        public static string? NameDataServer { get; set; }
        /// <summary>
        /// Название gRPC клиента
        /// </summary>
        public static string? NameGrpcTesting { get; set; }
        /// <summary>
        /// URL-адрес сервера для получения данных
        /// </summary>
        public static string? DataServerUrl { get; set; }
        /// <summary>
        /// URL-адрес gRPC сервера
        /// </summary>
        public static string? GrpcTestingUrl { get; set; }

    }
}
