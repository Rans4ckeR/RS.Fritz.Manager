using System.Runtime.Serialization;
using System.Xml;

namespace RS.Fritz.Manager.API;

internal sealed class DeviceHostsService(IHttpClientFactory httpClientFactory, INetworkService networkService) : IDeviceHostsService
{
    private readonly INetworkService networkService = networkService;
    private readonly IHttpClientFactory httpClientFactory = httpClientFactory;

    public async ValueTask<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetHostListPathResponse hostsGetHostListPathResponse = await internetGatewayDevice.HostsGetHostListPathAsync().ConfigureAwait(false);
        string hostListPath = hostsGetHostListPathResponse.HostListPath;
        Uri hostListPathUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, internetGatewayDevice.SecurityPort!.Value, hostListPath);
        Stream deviceHostsListXmlStream = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(hostListPathUri, cancellationToken).ConfigureAwait(false);

        await using (deviceHostsListXmlStream.ConfigureAwait(false))
        {
            using var xmlTextReader = new XmlTextReader(deviceHostsListXmlStream);
            var deviceHostsList = (DeviceHostsList)new DataContractSerializer(typeof(DeviceHostsList)).ReadObject(xmlTextReader)!;

            return new(hostListPath, hostListPathUri, deviceHostsList);
        }
    }
}