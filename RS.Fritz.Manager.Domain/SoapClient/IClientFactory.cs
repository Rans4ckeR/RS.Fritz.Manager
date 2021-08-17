namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.ServiceModel;

    public interface IClientFactory<TInterface>
    {
        TInterface Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, TInterface> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential);
    }
}