namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;
using System.Xml;

internal sealed class DeviceHostsService : IDeviceHostsService
{
    private readonly IHttpClientFactory httpClientFactory;

    public DeviceHostsService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetHostListPathResponse hostsGetHostListPathResponse = await internetGatewayDevice.HostsGetHostListPathAsync();
        string hostListPath = hostsGetHostListPathResponse.HostListPath;
        var hostListPathUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}:{internetGatewayDevice.SecurityPort}{hostListPath}"));
        await using Stream deviceHostsListXmlStream = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStreamAsync(hostListPathUri, cancellationToken);
        using var xmlTextReader = new XmlTextReader(deviceHostsListXmlStream);

        var deviceHostsList = (DeviceHostsList)new DataContractSerializer(typeof(DeviceHostsList)).ReadObject(xmlTextReader)!;

        return new DeviceHostInfo(hostListPath, hostListPathUri, deviceHostsList);
    }
}