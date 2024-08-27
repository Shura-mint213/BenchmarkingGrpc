namespace ProcessingServer.Interfaces
{
    public interface IUrlRequestsService
    {
        Task<string> GetOrdersToDataServer();
    }
}
