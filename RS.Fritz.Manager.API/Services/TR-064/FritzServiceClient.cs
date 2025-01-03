﻿using System.Net;
using System.Security.Authentication;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.Xml;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal abstract class FritzServiceClient<T> : ClientBase<T>
    where T : class
{
    protected FritzServiceClient(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential, ILoggerFactory loggerFactory)
        : base(GetBindingForEndpoint(endpointConfiguration), remoteAddress)
    {
        Endpoint.Name = endpointConfiguration.ToString();

        Endpoint.EndpointBehaviors.Add(new ClientMessageLoggingBehavior(loggerFactory.CreateLogger(GetType())));

        SetSslProtocols(SslProtocols.None);
        SetCredentials(networkCredential);
    }

    private static Binding GetBindingForEndpoint(FritzServiceEndpointConfiguration endpointConfiguration) =>
        endpointConfiguration switch
        {
            FritzServiceEndpointConfiguration.BasicHttpBindingIFritzService => new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                MaxReceivedMessageSize = int.MaxValue
            },
            FritzServiceEndpointConfiguration.BasicHttpsBindingIFritzService => new BasicHttpsBinding
            {
                MaxBufferSize = int.MaxValue,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                MaxReceivedMessageSize = int.MaxValue,
                Security =
                {
                    Mode = BasicHttpsSecurityMode.Transport,
                    Transport =
                    {
                        ClientCredentialType = HttpClientCredentialType.Digest
                    }
                }
            },
            _ => throw new ArgumentOutOfRangeException(nameof(endpointConfiguration), endpointConfiguration, null)
        };

    private void SetSslProtocols(SslProtocols sslProtocols)
    {
        _ = Endpoint.EndpointBehaviors.TryGetValue(typeof(SslProtocolCertificateEndpointBehavior), out IEndpointBehavior? behavior);

        if (behavior is null)
        {
            behavior = new SslProtocolCertificateEndpointBehavior();

            Endpoint.EndpointBehaviors.Add(behavior);
        }

        ((SslProtocolCertificateEndpointBehavior)behavior).SslProtocols = sslProtocols;
    }

    private void SetCredentials(NetworkCredential? networkCredential)
    {
        if (networkCredential is null)
            return;

        var clientCredentials = (ClientCredentials)Endpoint.EndpointBehaviors[typeof(ClientCredentials)];

        clientCredentials.HttpDigest.ClientCredential = networkCredential;
    }
}