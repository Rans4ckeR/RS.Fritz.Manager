namespace RS.Fritz.Manager.API;

public interface IDeviceMeshService
{
    ValueTask<DeviceMeshInfo> GetDeviceMeshAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}