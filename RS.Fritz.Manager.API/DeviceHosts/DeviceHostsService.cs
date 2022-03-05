namespace RS.Fritz.Manager.API
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;

    internal sealed class DeviceHostsService : IDeviceHostsService
    {
        private readonly IHttpClientFactory httpClientFactory;

        public DeviceHostsService(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<IEnumerable<DeviceHost>> GetDeviceHostsAsync(Uri hostListPathUri)
        {
            string deviceHostsListXml = await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(hostListPathUri);

            using var stringReader = new StringReader(deviceHostsListXml);
            using var xmlTextReader = new XmlTextReader(stringReader);

            DeviceHostsList? deviceHostsList = (DeviceHostsList?)new XmlSerializer(typeof(DeviceHostsList)).Deserialize(xmlTextReader);

            return deviceHostsList?.DeviceHosts ?? Array.Empty<DeviceHost>();
        }
    }
}