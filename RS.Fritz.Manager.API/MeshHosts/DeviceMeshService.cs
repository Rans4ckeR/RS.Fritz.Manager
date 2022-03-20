namespace RS.Fritz.Manager.API;

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

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

        var deviceMesh = (DeviceMesh?)await JsonSerializer.DeserializeAsync(deviceMeshJsonStream, typeof(DeviceMesh), cancellationToken: cancellationToken);

        return deviceMesh!;
    }
}