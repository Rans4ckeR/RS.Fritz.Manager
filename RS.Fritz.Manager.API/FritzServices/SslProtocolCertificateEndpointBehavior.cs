namespace RS.Fritz.Manager.API
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
                q.ServerCertificateCustomValidationCallback = (_, _, _, _) => true;

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