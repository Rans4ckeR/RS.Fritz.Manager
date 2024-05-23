namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzHostsService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzHostsService>(binding, remoteAddress), IFritzHostsService
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