namespace RS.Fritz.Manager.API;

public interface IDeviceMeshService
{
    Task<DeviceMeshInfo> GetDeviceMeshAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default);
}