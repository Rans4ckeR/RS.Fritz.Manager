namespace RS.Fritz.Manager.API;

public interface IDeviceHostsService
{
    Task<IEnumerable<DeviceHost>> GetDeviceHostsAsync(Uri hostListPathUri, CancellationToken cancellationToken = default);
}