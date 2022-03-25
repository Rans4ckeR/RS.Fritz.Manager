namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzLanHostConfigManagementService : FritzServiceClient<IFritzLanHostConfigManagementService>, IFritzLanHostConfigManagementService
{
    public const string ControlUrl = "/upnp/control/lanhostconfigmgm";

    public FritzLanHostConfigManagementService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential? networkCredential = null)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<LanHostConfigManagementGetInfoResponse> GetInfoAsync(LanHostConfigManagementGetInfoRequest lanHostConfigManagementGetInfoRequest)
    {
        return Channel.GetInfoAsync(lanHostConfigManagementGetInfoRequest);
    }
}