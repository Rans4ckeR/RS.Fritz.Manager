namespace RS.Fritz.Manager.API;

public interface IDeviceSearchService
{
    ValueTask<IEnumerable<InternetGatewayDevice>> GetDevicesAsync(string? deviceType = null, int? sendCount = null, int? timeout = null, CancellationToken cancellationToken = default);
}