namespace RS.Fritz.Manager.API;

using System.Text.Json;

internal sealed class DeviceMeshService(IHttpClientFactory httpClientFactory, INetworkService networkService) : IDeviceMeshService
{
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