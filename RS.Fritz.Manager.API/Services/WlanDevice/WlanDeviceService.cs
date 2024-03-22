namespace RS.Fritz.Manager.API;

using System.Xml;
using System.Xml.Serialization;

internal sealed class WlanDeviceService(IHttpClientFactory httpClientFactory, INetworkService networkService) : IWlanDeviceService
{
    public async ValueTask<WlanDeviceInfo> GetWlanDevicesAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        WlanConfigurationGetWlanDeviceListPathResponse wlanConfigurationGetWlanDeviceListPathResponse = await internetGatewayDevice.WlanConfigurationGetWlanDeviceListPathAsync(1).ConfigureAwait(false);
        string wlanDeviceListPath = wlanConfigurationGetWlanDeviceListPathResponse.WlanDeviceListPath;
        Uri wlanDeviceListPathUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation!, internetGatewayDevice.SecurityPort!.Value, wlanDeviceListPath);
        Stream wlanDeviceListXmlStream = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(wlanDeviceListPathUri, cancellationToken).ConfigureAwait(false);

        await using (wlanDeviceListXmlStream.ConfigureAwait(false))
        {
            using var xmlTextReader = new XmlTextReader(wlanDeviceListXmlStream);
            var wlanDeviceList = (WlanDeviceList)new XmlSerializer(typeof(WlanDeviceList)).Deserialize(xmlTextReader)!;

            return new(wlanDeviceListPath, wlanDeviceListPathUri, wlanDeviceList);
        }
    }
}