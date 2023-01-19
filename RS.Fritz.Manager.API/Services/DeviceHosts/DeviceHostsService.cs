﻿namespace RS.Fritz.Manager.API;

using System.Runtime.Serialization;
using System.Xml;

internal sealed class DeviceHostsService : IDeviceHostsService
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly INetworkService networkService;

    public DeviceHostsService(IHttpClientFactory httpClientFactory, INetworkService networkService)
    {
        this.httpClientFactory = httpClientFactory;
        this.networkService = networkService;
    }

    public async Task<DeviceHostInfo> GetDeviceHostsAsync(InternetGatewayDevice internetGatewayDevice, CancellationToken cancellationToken = default)
    {
        HostsGetHostListPathResponse hostsGetHostListPathResponse = await internetGatewayDevice.HostsGetHostListPathAsync();
        string hostListPath = hostsGetHostListPathResponse.HostListPath;
        Uri hostListPathUri = networkService.FormatUri(Uri.UriSchemeHttps, internetGatewayDevice.PreferredLocation, internetGatewayDevice.SecurityPort!.Value, hostListPath);
        Stream deviceHostsListXmlStream = await httpClientFactory.CreateClient(Constants.DefaultHttpClientName).GetStreamAsync(hostListPathUri, cancellationToken).ConfigureAwait(false);

        await using (deviceHostsListXmlStream.ConfigureAwait(false))
        {
            using var xmlTextReader = new XmlTextReader(deviceHostsListXmlStream);
            var deviceHostsList = (DeviceHostsList)new DataContractSerializer(typeof(DeviceHostsList)).ReadObject(xmlTextReader)!;

            return new(hostListPath, hostListPathUri, deviceHostsList);
        }
    }
}