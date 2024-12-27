using System.Text.Json;

namespace RS.Fritz.Manager.API;

internal sealed class DeviceMeshService(IHttpClientFactory httpClientFactory, INetworkService networkService) : IDeviceMeshService
{
    private readonly INetworkService networkService = networkService;
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

    public async ValueTask<DeviceMeshInfo> GetDeviceMeshAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetMeshListPathResponse hostsGetMeshListPathResponse = await internetGatewayDevice.HostsGetMeshListPathAsync().ConfigureAwait(false);
        string meshListPath = hostsGetMeshListPathResponse.MeshListPath;
        Uri meshListPathUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, internetGatewayDevice.SecurityPort!.Value, meshListPath);
        Stream deviceMeshJsonStream = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(meshListPathUri, cancellationToken).ConfigureAwait(false);

        await using (deviceMeshJsonStream.ConfigureAwait(false))
        {
            var deviceMesh = (DeviceMesh)(await JsonSerializer.DeserializeAsync(deviceMeshJsonStream, typeof(DeviceMesh), cancellationToken: cancellationToken).ConfigureAwait(false))!;

            return new(meshListPath, meshListPathUri, deviceMesh);
        }
    }
}