namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzWanDslInterfaceConfigService : FritzServiceClient<IFritzWanDslInterfaceConfigService>, IFritzWanDslInterfaceConfigService
{
    public const string ControlUrl = "/upnp/control/wandslifconfig1";

    public FritzWanDslInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> GetDslDiagnoseInfoAsync(WanDslInterfaceConfigGetDslDiagnoseInfoRequest wanDslInterfaceConfigGetDslDiagnoseInfoRequest)
        => Channel.GetDslDiagnoseInfoAsync(wanDslInterfaceConfigGetDslDiagnoseInfoRequest);

    public Task<WanDslInterfaceConfigGetDslInfoResponse> GetDslInfoAsync(WanDslInterfaceConfigGetDslInfoRequest wanDslInterfaceConfigGetDslInfoRequest)
        => Channel.GetDslInfoAsync(wanDslInterfaceConfigGetDslInfoRequest);

    public Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo)
        => Channel.GetInfoAsync(wanDslInterfaceConfigGetInfo);

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest)
        => Channel.GetStatisticsTotalAsync(wanDslInterfaceConfigGetStatisticsTotalRequest);
}