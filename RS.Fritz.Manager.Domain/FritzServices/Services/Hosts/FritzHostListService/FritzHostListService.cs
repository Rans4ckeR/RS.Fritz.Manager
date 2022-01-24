namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    using System.ServiceModel;
    using System.Threading.Tasks;



    public class FritzHostListService : FritzServiceClient<IFritzHostListService>, IFritzHostListService
    {
        //private readonly IHttpClientFactory httpClientFactory;

        //public FritzHostListService(IHttpClientFactory httpClientFactory)
        //public FritzHostListService()

        public const string ControlUrl = "/tr64desc.xml";

        public FritzHostListService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        /*
        {
            //this.httpClientFactory = httpClientFactory;
            int dummy5 = 1;
        }
        */
        //public Task<HostsGetHostListPathResponse> GetHostHostListAsync(HostsGetHostListRequest hostsGetHostListRequest);

        public Task<HostsGetHostListResponse> GetHostListAsync(HostsGetHostListRequest hostsGetHostListRequest)
        {
            return Channel.GetHostListAsync(hostsGetHostListRequest);
        }

        /*
        private async Task GetHostList(InternetGatewayDevice internetGatewayDevice)
            {
            Uri uri = internetGatewayDevice.Locations.SingleOrDefault(r => r.HostNameType == UriHostNameType.IPv6) ?? internetGatewayDevice.Locations.Single(r => r.HostNameType == UriHostNameType.IPv4);
            string uPnPDescription = await httpClientFactory.CreateClient(Constants.HttpClientName).GetStringAsync(uri);
            using var stringReader = new StringReader(uPnPDescription);
            using var xmlTextReader = new XmlTextReader(stringReader);

            internetGatewayDevice.UPnPDescription = (UPnPDescription?)new XmlSerializer(typeof(UPnPDescription)).Deserialize(xmlTextReader);
            // RoSchmi
            int dummy3 = 1;
        }
        */
    }
}