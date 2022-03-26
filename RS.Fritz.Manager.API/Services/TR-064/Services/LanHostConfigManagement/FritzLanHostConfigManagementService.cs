namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzLanHostConfigManagementService : FritzServiceClient<IFritzLanHostConfigManagementService>, IFritzLanHostConfigManagementService
{
    public const string ControlUrl = "/upnp/control/lanhostconfigmgm";

    public FritzLanHostConfigManagementService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<LanHostConfigManagementGetInfoResponse> GetInfoAsync(LanHostConfigManagementGetInfoRequest lanHostConfigManagementGetInfoRequest)
    {
        return Channel.GetInfoAsync(lanHostConfigManagementGetInfoRequest);
    }

    public Task<LanHostConfigManagementGetAddressRangeResponse> GetAddressRangeAsync(LanHostConfigManagementGetAddressRangeRequest lanHostConfigManagementGetAddressRangeRequest)
    {
        return Channel.GetAddressRangeAsync(lanHostConfigManagementGetAddressRangeRequest);
    }

    public Task<LanHostConfigManagementGetDnsServersResponse> GetDnsServersAsync(LanHostConfigManagementGetDnsServersRequest lanHostConfigManagementGetDnsServersRequest)
    {
        return Channel.GetDnsServersAsync(lanHostConfigManagementGetDnsServersRequest);
    }

    public Task<LanHostConfigManagementGetIpInterfaceNumberOfEntriesResponse> GetIpInterfaceNumberOfEntriesAsync(LanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest)
    {
        return Channel.GetIpInterfaceNumberOfEntriesAsync(lanHostConfigManagementGetIpInterfaceNumberOfEntriesRequest);
    }

    public Task<LanHostConfigManagementGetIpRoutersListResponse> GetIpRoutersListAsync(LanHostConfigManagementGetIpRoutersListRequest lanHostConfigManagementGetIpRoutersListRequest)
    {
        return Channel.GetIpRoutersListAsync(lanHostConfigManagementGetIpRoutersListRequest);
    }

    public Task<LanHostConfigManagementGetSubnetMaskResponse> GetSubnetMaskAsync(LanHostConfigManagementGetSubnetMaskRequest lanHostConfigManagementGetSubnetMaskRequest)
    {
        return Channel.GetSubnetMaskAsync(lanHostConfigManagementGetSubnetMaskRequest);
    }
}