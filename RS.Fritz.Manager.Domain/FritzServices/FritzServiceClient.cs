﻿namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.Security.Authentication;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.ServiceModel.Description;
    using System.Xml;

    public abstract partial class FritzServiceClient<TChannel> : ClientBase<TChannel>
        where TChannel : class
    {
        protected FritzServiceClient(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential)
            : base(GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            Endpoint.Name = endpointConfiguration.ToString();
            SslProtocols = SslProtocols.Tls12;

            if (networkCredential is null)
                return;

            var clientCredentials = (ClientCredentials)Endpoint.EndpointBehaviors[typeof(ClientCredentials)];

            clientCredentials.HttpDigest.ClientCredential = networkCredential;
        }

        public SslProtocols SslProtocols
        {
            get
            {
                _ = Endpoint.EndpointBehaviors.TryGetValue(typeof(SslProtocolCertificateEndpointBehavior), out IEndpointBehavior? behavior);

                if (behavior is null)
                    return SslProtocols.None;

                return ((SslProtocolCertificateEndpointBehavior)behavior).SslProtocols;
            }

            set
            {
                _ = Endpoint.EndpointBehaviors.TryGetValue(typeof(SslProtocolCertificateEndpointBehavior), out IEndpointBehavior? behavior);

                if (behavior is null)
                {
                    behavior = new SslProtocolCertificateEndpointBehavior();

                    Endpoint.EndpointBehaviors.Add(behavior);
                }

                ((SslProtocolCertificateEndpointBehavior)behavior).SslProtocols = value;
            }
        }

        private static Binding GetBindingForEndpoint(FritzServiceEndpointConfiguration endpointConfiguration)
        {
            return endpointConfiguration switch
            {
                FritzServiceEndpointConfiguration.BasicHttpBinding_IFritzService => new BasicHttpBinding
                {
                    MaxBufferSize = int.MaxValue,
                    ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                    MaxReceivedMessageSize = int.MaxValue,
                    AllowCookies = true
                },
                FritzServiceEndpointConfiguration.BasicHttpsBinding_IFritzService => new BasicHttpsBinding
                {
                    MaxBufferSize = int.MaxValue,
                    ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                    MaxReceivedMessageSize = int.MaxValue,
                    AllowCookies = true,
                    Security =
                    {
                        Mode = BasicHttpsSecurityMode.Transport,
                        Transport =
                        {
                            ClientCredentialType = HttpClientCredentialType.Digest
                        }
                    }
                },
                _ => throw new ArgumentOutOfRangeException(nameof(endpointConfiguration), endpointConfiguration, null),
            };
        }
    }
}