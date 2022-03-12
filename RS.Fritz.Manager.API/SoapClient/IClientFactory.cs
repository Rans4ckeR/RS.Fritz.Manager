namespace RS.Fritz.Manager.API;

using System;
using System.Net;
using System.ServiceModel;

internal interface IClientFactory<T>
{
    T Build(Func<FritzServiceEndpointConfiguration, EndpointAddress, NetworkCredential?, T> createClient, Uri location, bool secure, string controlUrl, ushort? port, NetworkCredential? networkCredential);
}