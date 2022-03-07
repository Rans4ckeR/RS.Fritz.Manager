namespace RS.Fritz.Manager.API
{
    using System;
    using System.Net;
    using System.ServiceModel;

    internal sealed class ClientFactory<TInterface> : IClientFactory<TInterface>
        where TInterface : class
    {
        public TInterface Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, TInterface> createClient, Uri location, bool secure, string controlUrl, ushort? port = null, NetworkCredential? networkCredential = null)
        {
            return createClient(GetEndpointConfiguration(secure), GetEndpointAddress(location, secure, controlUrl, port), networkCredential);
        }

        private static EndpointAddress GetEndpointAddress(Uri location, bool secure, string controlUrl, int? port = null)
        {
            return new EndpointAddress(new Uri(FormattableString.Invariant($"{(secure ? "https" : "http")}://{(port is null ? location.Authority : $"{location.Host}:{port.Value}")}{controlUrl}")));
        }

        private static FritzServiceEndpointConfiguration GetEndpointConfiguration(bool secure)
        {
            return secure ? FritzServiceEndpointConfiguration.BasicHttpsBinding_IFritzService : FritzServiceEndpointConfiguration.BasicHttpBinding_IFritzService;
        }
    }
}