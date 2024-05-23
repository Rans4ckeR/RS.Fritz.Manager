namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

internal sealed class HttpClientPoolingBehavior(IHttpMessageHandlerFactory httpMessageHandlerFactory, string clientName) : IEndpointBehavior
{
    public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        => bindingParameters.Add(new Func<HttpClientHandler, HttpMessageHandler>(originalHttpClientHandler =>
        {
            HttpMessageHandler httpMessageHandler = httpMessageHandlerFactory.CreateHandler(clientName);
            SocketsHttpHandler socketsHttpHandler = GetPrimaryHttpMessageHandler(httpMessageHandler);

            if (!socketsHttpHandler.Properties.TryAdd(nameof(HttpClientPoolingBehavior), null))
                return httpMessageHandler;

            socketsHttpHandler.AutomaticDecompression = originalHttpClientHandler.AutomaticDecompression;
            socketsHttpHandler.Proxy = originalHttpClientHandler.Proxy;
            socketsHttpHandler.UseProxy = originalHttpClientHandler.UseProxy;
            socketsHttpHandler.UseCookies = originalHttpClientHandler.UseCookies;
            socketsHttpHandler.CookieContainer = originalHttpClientHandler.CookieContainer;
            socketsHttpHandler.PreAuthenticate = originalHttpClientHandler.PreAuthenticate;
            socketsHttpHandler.Credentials = originalHttpClientHandler.Credentials;
            socketsHttpHandler.SslOptions.EnabledSslProtocols = originalHttpClientHandler.SslProtocols;
            socketsHttpHandler.SslOptions.ClientCertificates = originalHttpClientHandler.ClientCertificates;
#pragma warning disable CA5359 // Do Not Disable Certificate Validation
            socketsHttpHandler.SslOptions.RemoteCertificateValidationCallback = (_, _, _, _) => true;
#pragma warning restore CA5359 // Do Not Disable Certificate Validation

            return httpMessageHandler;
        }));

    public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
    {
    }

    public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
    {
    }

    public void Validate(ServiceEndpoint endpoint)
    {
    }

    private static SocketsHttpHandler GetPrimaryHttpMessageHandler(HttpMessageHandler httpMessageHandler)
    {
        while (true)
        {
            if (httpMessageHandler is not DelegatingHandler delegatingHandler)
                return (SocketsHttpHandler)httpMessageHandler;

            httpMessageHandler = delegatingHandler.InnerHandler!;
        }
    }
}