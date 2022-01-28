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
    using System.Net.Security;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using System.Xml;
    using System.Xml.Serialization;
    using System.ServiceModel;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Http;
    

    
    
    using Microsoft.Extensions.DependencyInjection;
    
    using Microsoft.Extensions.Logging;
    using RS.Fritz.Manager.Domain;

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




    public sealed class HttpGetService : FritzServiceClient<IFritzHostsService>, IHttpGetService
    {
        private readonly IHttpClientFactory? httpGetServiceClientFactory;
        //private readonly IClientFactory<IHttpGetService>? httpGetServiceClientFactory;
        private readonly IHttpGetService? httpGetServiceClient;



        public string ControlUrl = "/Hier muss es rein";

        private EndpointAddress endpointAddress;
        private NetworkCredential networkCredential;
        private FritzServiceEndpointConfiguration endpointConfiguration;



        //ServiceProvider myServiceProvider = new ServiceCollection();

        //private readonly IHttpClientFactory httpClientFactory;

        //public IClientFactory<IHttpGetService>? httpGetServiceClientFactory;



        //private HttpClient? client;



        //private readonly AddressFamily[] supportedAddressFamilies = { AddressFamily.InterNetwork, AddressFamily.InterNetworkV6 };




        /*
        public HttpGetService(IHttpClientFactory httpClientFactory) //: IHttpGetService //FritzServiceClient<IFritzHostListService>, IFritzHostListService
        {
            this.httpClientFactory = httpClientFactory;    
        }
        */

        //   public HttpGetService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, IHttpClientFactory httpClientFactory)
        public HttpGetService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, IHttpClientFactory httpGetServiceClientFactory)
               : base(endpointConfiguration, remoteAddress, networkCredential)
        {
            this.endpointAddress = remoteAddress;
            this.networkCredential = networkCredential;
            this.endpointConfiguration = endpointConfiguration;
            this.httpGetServiceClientFactory = httpGetServiceClientFactory;
            //this.httpGetServiceClient = httpGetServiceClient;

            



            //this.httpClientFactory = httpClientFactory;
            // this.httpGetServiceClientFactory = httpGetServiceClientFactory;
        }


        // public Task<string> GetHttpResponseAsync(HostsHttpGetRequest hostsHttpGetRequest)
        public async Task<string> GetHttpResponseAsync(IHttpGetService? httpGetServiceClient, HostsHttpGetRequest hostsHttpGetRequest)
        {
            ServiceCollection sc = new ServiceCollection();
            sc.AddHttpClient("LocalHttpClient")
                .ConfigureHttpClient((_, httpClient) =>
                {
                    httpClient.Timeout = TimeSpan.FromSeconds(60);
                    httpClient.DefaultRequestVersion = Version.Parse("2.0");
                })
                .ConfigurePrimaryHttpMessageHandler(_ => new HttpClientHandler
                {
                    AutomaticDecompression = DecompressionMethods.All,
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ClientCertificates = { new X509Certificate2("hsly9xxw87vmkybw.myfritz.net") },
                    SslProtocols = System.Security.Authentication.SslProtocols.Tls12,

                    //ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator,

                    ServerCertificateCustomValidationCallback = (HttpRequestMessage sender, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors) => true,
                });

            ServiceProvider serviceProvider = sc.BuildServiceProvider();



            var nonValidatingHttpClient = (HttpClient)serviceProvider.GetService(typeof(HttpClient));

            HttpClientHandler httpClientHandler = new HttpClientHandler
            {
                SslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                ServerCertificateCustomValidationCallback = ServerCertificateCustomValidation,


            };

            nonValidatingHttpClient = new HttpClient(httpClientHandler);

            await GetRequestResultAsync(nonValidatingHttpClient, endpointAddress.Uri);


            // HttpClient httpClient = new HttpClient();
            // var countOfServices = sc.Count;



            return "Hallo";

            // return Channel.GetHttpResponseAsync(hostsHttpGetRequest);
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
            return (sslErrors & SslPolicyErrors. RemoteCertificateNotAvailable) == 0;
        }
        




        private async Task<string> GetRequestResultAsync(HttpClient httpClient, Uri url)
        {
            //HttpClient httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri(this.endpointAddress.ToString());


            HttpResponseMessage? result = null;
            try
            {

                result = await httpClient.GetAsync(url);
            }
            catch (Exception ex)
            {
                string mess = ex.Message;    
            }

            var content = await httpClient.GetStringAsync(url);
            var message = result.RequestMessage;

            int dummy = 1;
            //return message;
            return content;
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
