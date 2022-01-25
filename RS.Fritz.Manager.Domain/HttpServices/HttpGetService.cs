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
    using Microsoft.Extensions.Http;

    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Input;
    
    using Microsoft.Extensions.DependencyInjection;
    
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;


    

    public sealed class HttpGetService : FritzServiceClient<IFritzHostsService>, IHttpGetService
    {

        public string ControlUrl = "/Hier muss es rein";

        public IClientFactory<IHttpGetService>? httpGetServiceClientFactory;

        //private readonly IHttpClientFactory? httpClientFactory;

        private HttpClient? client;

        

        //private readonly AddressFamily[] supportedAddressFamilies = { AddressFamily.InterNetwork, AddressFamily.InterNetworkV6 };




        /*
        public HttpGetService(IHttpClientFactory httpClientFactory) //: IHttpGetService //FritzServiceClient<IFritzHostListService>, IFritzHostListService
        {
            this.httpClientFactory = httpClientFactory;    
        }
        */
        
        public HttpGetService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
            //this.httpClientFactory = httpClientFactory;
            this.httpGetServiceClientFactory = httpGetServiceClientFactory;
        }


        public Task<string> GetHttpResponseAsync(HostsHttpGetRequest hostsHttpGetRequest)
        {
           return Channel.GetHttpResponseAsync(hostsHttpGetRequest);
        }



        //public async Task<string> GetHttpResponse(Uri uri)
        public async Task<string> GetHttpResponseAsync(Uri preferredLocation, bool secure, string controlUrl, ushort? securityPort, NetworkCredential? networkCredential) //, FritzServiceOperationHandler networkCredential)

        {

           // ClientFactory<IHttpGetService> clientFactory;

          //  httpGetServiceClientFactory

          //  httpGetServiceClientFactory.Build


         //   clientFactory.Build((q, r, t) => new HttpGetService(q, r, t!), preferredLocation, true, controlUrl, securityPort, networkCredential);

            /*
            client = httpClientFactory.CreateClient(Constants.HttpClientName);

            ServiceProvider  myServiceProvider = new ServiceCollection<IServiceCollection>()
                .AddHttpClient(Constants.HttpClientName)
                .Configure<HttpClientFactoryOptions>(Constants.HttpClientName, options =>
            options.HttpMessageHandlerBuilderActions.Add(builder =>
                builder.PrimaryHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (m, crt, chn, e) => true
                }))
        .BuildServiceProvider();
            */

            //var myHttpClient = httpClientFactory.CreateClient(Constants.HttpClientName);
            // myHttpClient.



            await Task.Delay(10);
            // Uri uri = new Uri("http://192.168.1.1:49000/tr64desc.xml");

            // string theResponse = await httpClientFactory.CreateClient(Constants.HttpClientName).GetStringAsync(uri);

            string theResponse = "hallo";

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
