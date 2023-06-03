namespace RS.Fritz.Manager.API;

public interface IWlanDeviceService
{
    ValueTask<WlanDeviceInfo> GetWlanDevicesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}