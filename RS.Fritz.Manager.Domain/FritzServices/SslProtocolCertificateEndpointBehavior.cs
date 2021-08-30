namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net.Http;
    using System.Net.Security;
    using System.Security.Authentication;
    using System.Security.Cryptography.X509Certificates;
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
                q.ServerCertificateCustomValidationCallback = ServerCertificateCustomValidationCallback;

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

        private static bool ServerCertificateCustomValidationCallback(HttpRequestMessage sender, X509Certificate2? certificate, X509Chain? chain, SslPolicyErrors sslPolicyErrors)
        {
            if (certificate is null || chain is null)
                return false;

            if (sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateChainErrors) || sslPolicyErrors.HasFlag(SslPolicyErrors.RemoteCertificateNotAvailable))
                return false;

            chain.ChainPolicy.RevocationMode = X509RevocationMode.Online;
            chain.ChainPolicy.RevocationFlag = X509RevocationFlag.EntireChain;
            chain.ChainPolicy.UrlRetrievalTimeout = TimeSpan.FromSeconds(10);
            chain.ChainPolicy.VerificationTime = DateTime.Now;
            chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;

            return chain.Build(certificate);
        }
    }
}