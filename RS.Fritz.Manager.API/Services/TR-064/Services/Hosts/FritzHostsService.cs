namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzHostsService : FritzServiceClient<IFritzHostsService>, IFritzHostsService
{
    public const string ControlUrl = "/upnp/control/hosts";

    public FritzHostsService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest)
    {
        return Channel.GetHostNumberOfEntriesAsync(hostsGetHostNumberOfEntriesRequest);
    }

    public Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest)
    {
        return Channel.GetHostListPathAsync(hostsGetHostListPathRequest);
    }

    public Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest)
    {
        return Channel.GetGenericHostEntryAsync(hostsGetGenericHostEntryRequest);
    }

    public Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest)
    {
        return Channel.GetChangeCounterAsync(hostsGetChangeCounterRequest);
    }

    public Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest)
    {
        return Channel.GetMeshListPathAsync(hostsGetMeshListPathRequest);
    }
}