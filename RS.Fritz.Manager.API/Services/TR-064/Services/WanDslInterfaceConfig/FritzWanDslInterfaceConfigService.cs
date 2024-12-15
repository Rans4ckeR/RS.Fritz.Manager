using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzWanDslInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzWanDslInterfaceConfigService>(endpointConfiguration, remoteAddress, networkCredential), IFritzWanDslInterfaceConfigService
{
    public Task<WanDslInterfaceConfigGetDslDiagnoseInfoResponse> GetDslDiagnoseInfoAsync(WanDslInterfaceConfigGetDslDiagnoseInfoRequest wanDslInterfaceConfigGetDslDiagnoseInfoRequest)
        => Channel.GetDslDiagnoseInfoAsync(wanDslInterfaceConfigGetDslDiagnoseInfoRequest);

    public Task<WanDslInterfaceConfigGetDslInfoResponse> GetDslInfoAsync(WanDslInterfaceConfigGetDslInfoRequest wanDslInterfaceConfigGetDslInfoRequest)
        => Channel.GetDslInfoAsync(wanDslInterfaceConfigGetDslInfoRequest);

    public Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo)
        => Channel.GetInfoAsync(wanDslInterfaceConfigGetInfo);

    public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest)
        => Channel.GetStatisticsTotalAsync(wanDslInterfaceConfigGetStatisticsTotalRequest);
}