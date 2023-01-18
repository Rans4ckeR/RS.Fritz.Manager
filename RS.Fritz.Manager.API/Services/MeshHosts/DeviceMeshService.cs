namespace RS.Fritz.Manager.API;

using System.Text.Json;

internal sealed class DeviceMeshService : IDeviceMeshService
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly INetworkService networkService;

    public DeviceMeshService(IHttpClientFactory httpClientFactory, INetworkService networkService)
    {
        this.httpClientFactory = httpClientFactory;
        this.networkService = networkService;
    }

    public async Task<DeviceMeshInfo> GetDeviceMeshAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetMeshListPathResponse hostsGetMeshListPathResponse = await internetGatewayDevice.HostsGetMeshListPathAsync();
        string meshListPath = hostsGetMeshListPathResponse.MeshListPath;
        Uri meshListPathUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation, internetGatewayDevice.SecurityPort!.Value, meshListPath);
        await using Stream deviceMeshJsonStream = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(meshListPathUri, cancellationToken);
        var deviceMesh = (DeviceMesh)(await JsonSerializer.DeserializeAsync(deviceMeshJsonStream, typeof(DeviceMesh), cancellationToken: cancellationToken))!;

        return new(meshListPath, meshListPathUri, deviceMesh);
    }
}