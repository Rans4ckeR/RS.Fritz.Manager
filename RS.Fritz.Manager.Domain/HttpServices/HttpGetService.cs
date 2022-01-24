namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
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

    public sealed class HttpGetService : IHttpGetService
    {

        private readonly IHttpClientFactory httpClientFactory;
        //private readonly AddressFamily[] supportedAddressFamilies = { AddressFamily.InterNetwork, AddressFamily.InterNetworkV6 };

        public HttpGetService(IHttpClientFactory httpClientFactory) //: IHttpGetService //FritzServiceClient<IFritzHostListService>, IFritzHostListService
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetHttpResponse(Uri uri)
        {
            await Task.Delay(10);
            // Uri uri = new Uri("http://192.168.1.1:49000/tr64desc.xml");
            string theResponse = await httpClientFactory.CreateClient(Constants.HttpClientName).GetStringAsync(uri);
            return theResponse;
        }


        /*
        private async Task GetUPnPDescription(InternetGatewayDevice internetGatewayDevice)
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
