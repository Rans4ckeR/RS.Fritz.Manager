namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzWANCommonInterfaceConfigService : FritzServiceClient<IFritzWanCommonInterfaceConfigService>, IFritzWanCommonInterfaceConfigService
    {
        public const string ControlUrl = "/upnp/control/wancommonifconfig1";

        public FritzWANCommonInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }
        public Task<WanCommonInterfaceConfigGetTotalBytesReceivedResponse> GetTotalBytesReceivedAsync(WanCommonInterfaceConfigGetTotalBytesReceivedRequest wanCommonInterfaceConfigGetTotalBytesReceivedRequest)
        {
            return Channel.GetTotalBytesReceivedAsync(wanCommonInterfaceConfigGetTotalBytesReceivedRequest);
        }
        /*
        public Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> GetDSLDiagnoseInfoAsync(WanDslInterfaceConfigGetDSLDiagnoseInfoRequest wanDslInterfaceConfigGetDSLDiagnoseInfoRequest)
        {
            return Channel.GetDSLDiagnoseInfoAsync(wanDslInterfaceConfigGetDSLDiagnoseInfoRequest);
        }

        public Task<WanDslInterfaceConfigGetDSLInfoResponse> GetDSLInfoAsync(WanDslInterfaceConfigGetDSLInfoRequest wanDslInterfaceConfigGetDSLInfoRequest)
        {
            return Channel.GetDSLInfoAsync(wanDslInterfaceConfigGetDSLInfoRequest);
        }

        public Task<WanDslInterfaceConfigGetInfoResponse> GetInfoAsync(WanDslInterfaceConfigGetInfoRequest wanDslInterfaceConfigGetInfo)
        {
            return Channel.GetInfoAsync(wanDslInterfaceConfigGetInfo);
        }

        public Task<WanDslInterfaceConfigGetStatisticsTotalResponse> GetStatisticsTotalAsync(WanDslInterfaceConfigGetStatisticsTotalRequest wanDslInterfaceConfigGetStatisticsTotalRequest)
        {
            return Channel.GetStatisticsTotalAsync(wanDslInterfaceConfigGetStatisticsTotalRequest);
        }
        */
    }
}