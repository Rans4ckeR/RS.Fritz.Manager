namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;

    public sealed class FritzHttpOperationHandler : ServiceOperationHandler, IFritzHttpOperationHandler
    {
        private readonly IHttpClientFactory httpClientFactory;

        public FritzHttpOperationHandler(
            IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        public async Task<string> GetHostsGetHostListAsync(Uri uri)
        {
            return await httpClientFactory.CreateClient(Constants.NonValidatingHttpsClientName).GetStringAsync(uri);
        }
    }
}