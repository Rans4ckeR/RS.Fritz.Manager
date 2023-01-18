namespace RS.Fritz.Manager.API;

using System.Net;

internal interface INetworkService
{
    public Uri FormatUri(string scheme, Uri uri, ushort port, string path);

    public Uri FormatUri(IPEndPoint ipEndPoint);
}