namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Threading.Tasks;
    using System.Net;
    using System.Net.Http;
    using System.Net.Security;
    using System.Xml;
    using System.Xml.Serialization;
    using System.ServiceModel;
    using System.Security.Cryptography.X509Certificates;
    using Microsoft.Extensions.DependencyInjection;
    
    using Microsoft.Extensions.Logging;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    
    using System.Net.NetworkInformation;
    using System.Net.Sockets;
    using System.Text;
    
    public sealed class HttpsNonValGetService : IHttpGetService 
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly EndpointAddress endpointAddress;
        private readonly NetworkCredential networkCredential;
        private readonly FritzServiceEndpointConfiguration endpointConfiguration;

        public string ControlUrl = "/Hier muss es rein";

        public HttpsNonValGetService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, IHttpClientFactory httpClientFactory)
        {
            this.endpointAddress = remoteAddress;
            this.networkCredential = networkCredential;
            this.endpointConfiguration = endpointConfiguration;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetHttpResponseAsync()
        {

            // Configuration is done in App.xaml.cs
            HttpClient httpClient = httpClientFactory.CreateClient(Constants.NonValidatingHttpClientName);

            HttpResponseMessage? result = await httpClient.GetAsync(endpointAddress.Uri);

            string content = string.Empty;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                content = await httpClient.GetStringAsync(endpointAddress.Uri);
            }

            return content;

            //return Channel.GetHttpResponseAsync(hostsHttpGetRequest);
        }

        public async Task<string> GetHttpResponseAsync(Uri preferredLocation, bool secure, string controlUrl, ushort? securityPort, NetworkCredential? networkCredential)
        {
            // Overload not implemented
            await Task.Delay(1);
            return string.Empty;
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
