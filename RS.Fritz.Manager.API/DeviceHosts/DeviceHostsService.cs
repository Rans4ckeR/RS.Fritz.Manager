namespace RS.Fritz.Manager.API;

using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;

internal sealed class DeviceHostsService : IDeviceHostsService
{
    private readonly IHttpClientFactory httpClientFactory;

    public DeviceHostsService(IHttpClientFactory httpClientFactory)
    {
        this.httpClientFactory = httpClientFactory;
    }

    public async Task<IEnumerable<DeviceHost>> GetDeviceHostsAsync(Uri hostListPathUri, CancellationToken cancellationToken = default)
    {
        string deviceHostsListXml = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(hostListPathUri, cancellationToken);

        using var stringReader = new StringReader(deviceHostsListXml);
        using var xmlTextReader = new XmlTextReader(stringReader);

        var deviceHostsList = (DeviceHostsList?)new DataContractSerializer(typeof(DeviceHostsList)).ReadObject(xmlTextReader);

        return deviceHostsList ?? new DeviceHostsList();
    }
}