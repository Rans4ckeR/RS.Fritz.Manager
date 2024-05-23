namespace RS.Fritz.Manager.API;

using System.Net;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;

internal sealed class ClientFactory<TInterface, TClient>(INetworkService networkService, IHttpMessageHandlerFactory httpMessageHandlerFactory, Func<Binding, EndpointAddress, TClient> factoryFunc)
    : IClientFactory<TClient>
    where TInterface : class, IFritzService
    where TClient : ClientBase<TInterface>, TInterface
{
    private EndpointAddress? endpointAddress;
    private HttpBindingBase? binding;

    public TClient Build(Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential)
    {
        if (endpointAddress is null)
        {
            Uri endPointUri = networkService.FormatUri(secure ? Uri.UriSchemeHttps : Uri.UriSchemeHttp, location, port ?? (ushort)location.Port, controlUrl);

            endpointAddress ??= new(endPointUri, (EndpointIdentity?)null);
        }

        binding ??= CreateBinding();

        TClient client = factoryFunc(binding, endpointAddress);

        if (!client.Endpoint.EndpointBehaviors.Contains(typeof(HttpClientPoolingBehavior)))
            client.Endpoint.EndpointBehaviors.Add(new HttpClientPoolingBehavior(httpMessageHandlerFactory, typeof(TInterface).ToString()));

        if (networkCredential is null)
            return client;

        var clientCredentials = (ClientCredentials)client.Endpoint.EndpointBehaviors[typeof(ClientCredentials)];

        clientCredentials.HttpDigest.ClientCredential = networkCredential;

        return client;
    }

    private HttpBindingBase CreateBinding()
    {
        HttpBindingBase httpBindingBase = InferBinding();

        httpBindingBase.SendTimeout = TimeSpan.FromSeconds(10);
        httpBindingBase.MaxReceivedMessageSize = int.MaxValue;
        httpBindingBase.MaxBufferSize = int.MaxValue;
        httpBindingBase.ReaderQuotas = XmlDictionaryReaderQuotas.Max;

        if (httpBindingBase is BasicHttpsBinding basicHttpsBinding)
        {
            basicHttpsBinding.Security = new()
            {
                Mode = BasicHttpsSecurityMode.Transport,
                Transport =
                {
                    ClientCredentialType = HttpClientCredentialType.Digest
                }
            };
        }

        return httpBindingBase;
    }

    private HttpBindingBase InferBinding() =>
        endpointAddress!.Uri.Scheme.Equals(Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
            ? new BasicHttpsBinding()
            : endpointAddress.Uri.Scheme.Equals(Uri.UriSchemeHttp, StringComparison.OrdinalIgnoreCase)
                ? new BasicHttpBinding()
                : throw new ArgumentOutOfRangeException(nameof(endpointAddress.Uri.Scheme), endpointAddress.Uri.Scheme, null);
}