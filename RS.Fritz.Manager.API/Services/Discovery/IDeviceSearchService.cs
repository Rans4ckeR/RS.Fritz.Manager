namespace RS.Fritz.Manager.API;

public interface IDeviceSearchService
{
    ValueTask<IEnumerable<ServerDeviceResponse>> GetDevicesAsync(string deviceType = UPnPConstants.RootDeviceDeviceType, int sendCount = 1, int timeout = 2000, CancellationToken cancellationToken = default);

    ValueTask<IEnumerable<GroupedInternetGatewayDevice>> GetInternetGatewayDevicesAsync(int sendCount = 1, int timeout = 2000, CancellationToken cancellationToken = default);
}