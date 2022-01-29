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
    
    public sealed class HttpGetService : FritzServiceClient<IFritzHostsService>, IHttpGetService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly EndpointAddress endpointAddress;
        private readonly NetworkCredential networkCredential;
        private readonly FritzServiceEndpointConfiguration endpointConfiguration;

        public string ControlUrl = "/Hier muss es rein";

        public HttpGetService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, IHttpClientFactory httpClientFactory)
               : base(endpointConfiguration, remoteAddress, networkCredential)
        {
            this.endpointAddress = remoteAddress;
            this.networkCredential = networkCredential;
            this.endpointConfiguration = endpointConfiguration;
            this.httpClientFactory = httpClientFactory;
        }


        public async Task<string> GetHttpResponseAsync()
        //public async Task<string> GetHttpResponseAsync(HostsHttpGetRequest hostsHttpGetRequest)

        //public async Task<string> GetHttpResponseAsync(IHttpGetService? httpGetServiceClient, HostsHttpGetRequest hostsHttpGetRequest)
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

        private static bool ServerCertificateCustomValidation(HttpRequestMessage? requestMessage, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslErrors)
        {
            // It is possible inpect the certificate provided by server
            string? requestedUri = requestMessage.RequestUri.AbsoluteUri;
            string effectivedate = certificate.GetEffectiveDateString();
            string expDate = certificate.GetExpirationDateString();
            string issuer = certificate.Issuer;
            string subject = certificate.Subject;

            // Based on the custom logic it is possible to decide whether the client considers certificate valid or not
            // Don't care NameMismatch and ChainErrors
            return (sslErrors & SslPolicyErrors.RemoteCertificateNotAvailable) == 0;
        }

        //public async Task<string> GetHttpResponse(Uri uri)
        public async Task<string> GetHttpResponseAsync(Uri preferredLocation, bool secure, string controlUrl, ushort? securityPort, NetworkCredential? networkCredential) //, FritzServiceOperationHandler networkCredential)

        {

           

            //ClientFactory<IHttpGetService> clientFactory;

            //httpGetServiceClientFactory

            //httpGetServiceClientFactory.Build


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
