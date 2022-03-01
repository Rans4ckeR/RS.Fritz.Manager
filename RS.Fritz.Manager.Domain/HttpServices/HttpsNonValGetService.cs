namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class HttpsNonValGetService : IHttpGetService
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly EndpointAddress endpointAddress;
        private readonly NetworkCredential networkCredential;
        private readonly FritzServiceEndpointConfiguration endpointConfiguration;

        public HttpsNonValGetService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, IHttpClientFactory httpClientFactory)
        {
            this.endpointAddress = remoteAddress;
            this.networkCredential = networkCredential;
            this.endpointConfiguration = endpointConfiguration;
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetHttpResponseAsync()
        {
            HttpClient httpClient = httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName);

            HttpResponseMessage? result = await httpClient.GetAsync(endpointAddress.Uri);

            string content = string.Empty;
            if (result.StatusCode == HttpStatusCode.OK)
            {
                content = await httpClient.GetStringAsync(endpointAddress.Uri);
            }

            return content;
        }

        /*
        public async Task<string> GetHttpResponseAsync(Uri preferredLocation, bool secure, string controlUrl, ushort? securityPort, NetworkCredential? networkCredential)
        {
            // Overload not implemented
            await Task.Delay(1);
            return string.Empty;
        }
        */
    }
}