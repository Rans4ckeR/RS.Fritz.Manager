namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net.Http;
    using System.Security.Authentication;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.ServiceModel.Dispatcher;

    internal sealed class SslProtocolCertificateEndpointBehavior : IEndpointBehavior
    {
        public SslProtocols SslProtocols { get; set; }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            bindingParameters.Add(new Func<HttpClientHandler, HttpMessageHandler>(q =>
            {
                q.SslProtocols = SslProtocols;
#pragma warning disable S4830 // Server certificates should be verified during SSL/TLS connections
                q.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;
#pragma warning restore S4830 // Server certificates should be verified during SSL/TLS connections

                return q;
            }));
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            // Method intentionally left empty.
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            // Method intentionally left empty.
        }

        public void Validate(ServiceEndpoint endpoint)
        {
            // Method intentionally left empty.
        }
    }
}