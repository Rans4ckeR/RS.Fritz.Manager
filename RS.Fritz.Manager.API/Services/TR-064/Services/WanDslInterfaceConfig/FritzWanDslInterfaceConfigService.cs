namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzWanDslInterfaceConfigService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzWanDslInterfaceConfigService>(binding, remoteAddress), IFritzWanDslInterfaceConfigService
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