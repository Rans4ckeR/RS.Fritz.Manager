namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public interface IHttpGetService
    {
        // Task<string> GetHttpResponse(Uri uri);
        //Task<string> GetHttpResponseAsync(Uri preferredLocation, bool secure, string controlUrl, ushort? securityPort, NetworkCredential? networkCredential); // FritzServiceOperationHandler networkCredential);
        Task<string> GetHttpResponseAsync(HostsHttpGetRequest hostsHttpGetRequest); // FritzServiceOperationHandler networkCre
    }
}