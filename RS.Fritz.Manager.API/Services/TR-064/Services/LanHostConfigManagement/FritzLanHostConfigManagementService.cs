namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzLanHostConfigManagementService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzLanHostConfigManagementService>(binding, remoteAddress), IFritzLanHostConfigManagementService
{
    public Task<LanHostConfigManagementGetInfoResponse> GetInfoAsync(LanHostConfigManagementGetInfoRequest lanHostConfigManagementGetInfoRequest)
        => Channel.GetInfoAsync(lanHostConfigManagementGetInfoRequest);

    public Task<LanHostConfigManagementGetAddressRangeResponse> GetAddressRangeAsync(LanHostConfigManagementGetAddressRangeRequest lanHostConfigManagementGetAddressRangeRequest)
        => Channel.GetAddressRangeAsync(lanHostConfigManagementGetAddressRangeRequest);

    public Task<LanHostConfigManagementGetDnsServersResponse> GetDnsServersAsync(LanHostConfigManagementGetDnsServersRequest lanHostConfigManagementGetDnsServersRequest)
        => Channel.GetDnsServersAsync(lanHostConfigManagementGetDnsServersRequest);

    public Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> GetIpInterfaceNumberOfEntriesAsync(LanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest)
        => Channel.GetIpInterfaceNumberOfEntriesAsync(lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest);

    public Task<LanHostConfigManagementGetIpRoutersListResponse> GetIpRoutersListAsync(LanHostConfigManagementGetIpRoutersListRequest lanHostConfigManagementGetIpRoutersListRequest)
        => Channel.GetIpRoutersListAsync(lanHostConfigManagementGetIpRoutersListRequest);

    public Task<LanHostConfigManagementGetSubnetMaskResponse> GetSubnetMaskAsync(LanHostConfigManagementGetSubnetMaskRequest lanHostConfigManagementGetSubnetMaskRequest)
        => Channel.GetSubnetMaskAsync(lanHostConfigManagementGetSubnetMaskRequest);
}