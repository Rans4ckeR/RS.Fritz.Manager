namespace RS.Fritz.Manager.API;

using System.Xml;
using System.Xml.Serialization;

internal sealed class WlanDeviceService : IWlanDeviceService
{
    private readonly IHttpClientFactory httpClientFactory;

    public WlanDeviceService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<WlanDeviceInfo> GetWlanDevicesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        WlanConfigurationGetWlanDeviceListPathResponse wlanConfigurationGetWlanDeviceListPathResponse = await internetGatewayDevice.WlanConfigurationGetWlanDeviceListPathAsync(1);
        string wlanDeviceListPath = wlanConfigurationGetWlanDeviceListPathResponse.WlanDeviceListPath;
        var wlanDeviceListPathUri = new Uri(FormattableString.Invariant($"https://{internetGatewayDevice.PreferredLocation.Host}:{internetGatewayDevice.SecurityPort}{wlanDeviceListPath}"));
        await using Stream wlanDeviceListXmlStream = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStreamAsync(wlanDeviceListPathUri, cancellationToken);
        using var xmlTextReader = new XmlTextReader(wlanDeviceListXmlStream);
        var wlanDeviceList = (WlanDeviceList)new XmlSerializer(typeof(WlanDeviceList)).Deserialize(xmlTextReader)!;

        return new WlanDeviceInfo(wlanDeviceListPath, wlanDeviceListPathUri, wlanDeviceList);
    }
}