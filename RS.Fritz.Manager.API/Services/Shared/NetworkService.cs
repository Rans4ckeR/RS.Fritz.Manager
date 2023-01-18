namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class NetworkService : INetworkService
{
    public Uri FormatUri(string scheme, Uri uri, ushort port, string path)
    {
        string[] pathAndQuery = path.Split('?');
        var uriBuilder = new UriBuilder(uri)
        {
            Scheme = scheme,
            Host = uri.IdnHost,
            Port = port,
            Path = pathAndQuery.First(),
            Query = pathAndQuery.Skip(1).SingleOrDefault()
        };

        return uriBuilder.Uri;
    }

    public Uri FormatUri(IPEndPoint ipEndPoint)
    {
        var uriBuilder = new UriBuilder(Uri.UriSchemeHttps, ipEndPoint.Address.ToString(), ipEndPoint.Port);

        return uriBuilder.Uri;
    }
}