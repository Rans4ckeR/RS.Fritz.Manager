namespace RS.Fritz.Manager.API;

using System.Text.Json;

internal sealed class DeviceMeshService : IDeviceMeshService
{
    private readonly IHttpClientFactory httpClientFactory;

    public DeviceMeshService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<DeviceMesh> GetDeviceMeshAsync(Uri meshListPathUri, CancellationToken cancellationToken = default)
    {
        await using Stream deviceMeshJsonStream = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStreamAsync(meshListPathUri, cancellationToken);

        return (DeviceMesh)(await JsonSerializer.DeserializeAsync(deviceMeshJsonStream, typeof(DeviceMesh), cancellationToken: cancellationToken))!;
    }
}