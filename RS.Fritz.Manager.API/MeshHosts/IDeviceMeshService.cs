namespace RS.Fritz.Manager.API;

public interface IDeviceMeshService
{
    Task<DeviceMesh> GetDeviceMeshAsync(Uri meshListPathUri, CancellationToken cancellationToken = default);
}