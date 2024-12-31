using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzHostsService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzHostsService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzHostsService
{
    public Task<HostsGetHostNumberOfEntriesResponse> GetHostNumberOfEntriesAsync(HostsGetHostNumberOfEntriesRequest hostsGetHostNumberOfEntriesRequest)
        => Channel.GetHostNumberOfEntriesAsync(hostsGetHostNumberOfEntriesRequest);

    public Task<HostsHostsCheckUpdateResponse> HostsCheckUpdateAsync(HostsHostsCheckUpdateRequest hostsHostsCheckUpdateRequest)
        => Channel.HostsCheckUpdateAsync(hostsHostsCheckUpdateRequest);

    public Task<HostsGetHostListPathResponse> GetHostListPathAsync(HostsGetHostListPathRequest hostsGetHostListPathRequest)
        => Channel.GetHostListPathAsync(hostsGetHostListPathRequest);

    public Task<HostsGetGenericHostEntryResponse> GetGenericHostEntryAsync(HostsGetGenericHostEntryRequest hostsGetGenericHostEntryRequest)
        => Channel.GetGenericHostEntryAsync(hostsGetGenericHostEntryRequest);

    public Task<HostsGetInfoResponse> GetInfoAsync(HostsGetInfoRequest hostsGetInfoRequest)
        => Channel.GetInfoAsync(hostsGetInfoRequest);

    public Task<HostsGetChangeCounterResponse> GetChangeCounterAsync(HostsGetChangeCounterRequest hostsGetChangeCounterRequest)
        => Channel.GetChangeCounterAsync(hostsGetChangeCounterRequest);

    public Task<HostsGetMeshListPathResponse> GetMeshListPathAsync(HostsGetMeshListPathRequest hostsGetMeshListPathRequest)
        => Channel.GetMeshListPathAsync(hostsGetMeshListPathRequest);

    public Task<HostsGetFriendlyNameResponse> GetFriendlyNameAsync(HostsGetFriendlyNameRequest hostsGetFriendlyNameRequest)
        => Channel.GetFriendlyNameAsync(hostsGetFriendlyNameRequest);
}