namespace RS.Fritz.Manager.API;

public interface IDeviceSearchService
{
    Task<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default);
}