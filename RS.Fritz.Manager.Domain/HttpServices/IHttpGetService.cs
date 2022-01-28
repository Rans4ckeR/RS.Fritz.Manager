namespace RS.Fritz.Manager.Domain
{
    using System;
    using System.Net;
    using System.Threading.Tasks;

    public interface IHttpGetService
    {
        //Task<string> GetHttpResponseAsync(IHttpGetService? httpGetServiceClient, HostsHttpGetRequest hostsHttpGetRequest);
        //Task<string> GetHttpResponseAsync(HostsHttpGetRequest hostsHttpGetRequest);
        Task<string> GetHttpResponseAsync();
    }
}