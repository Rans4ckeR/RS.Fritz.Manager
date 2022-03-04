﻿namespace RS.Fritz.Manager.API
{
    using System;
    using System.Net;
    using System.ServiceModel;

    public interface IClientFactory<TInterface>
    {
        TInterface Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, TInterface> createClient, Uri location, bool secure, string controlUrl, ushort? port = null, NetworkCredential? networkCredential = null);
    }
}