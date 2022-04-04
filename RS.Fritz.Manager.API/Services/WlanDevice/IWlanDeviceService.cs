namespace RS.Fritz.Manager.API;

public interface IWlanDeviceService
{
    Task<WlanDeviceInfo> GetWlanDevicesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}