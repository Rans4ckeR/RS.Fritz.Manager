namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public sealed class FritzHttpOperationHandler : ServiceOperationHandler, IFritzHttpOperationHandler
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly IClientFactory<IHttpGetService> httpGetServiceClientFactory;
        private readonly IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory;

        public FritzHttpOperationHandler(
            IHttpClientFactory httpClientFactory,
            IClientFactory<IHttpGetService> httpGetServiceClientFactory,
            IClientFactory<IFritzHostsService> fritzHostsServiceClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
            this.httpGetServiceClientFactory = httpGetServiceClientFactory;
            this.fritzHostsServiceClientFactory = fritzHostsServiceClientFactory;
        }

        public NetworkCredential? NetworkCredential { get; set; }

        public InternetGatewayDevice? InternetGatewayDevice { get; set; }

        public async Task<string> GetHostsGetHostListAsync(Uri uri)
        {
            return await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(uri);
        }
    }
}