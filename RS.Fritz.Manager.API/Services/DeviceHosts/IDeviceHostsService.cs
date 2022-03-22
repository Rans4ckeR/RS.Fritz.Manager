namespace RS.Fritz.Manager.API;

public interface IDeviceHostsService
{
    Task<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}