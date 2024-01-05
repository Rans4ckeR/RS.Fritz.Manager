namespace RS.Fritz.Manager.API;

public interface IDeviceHostsService
{
    ValueTask<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}