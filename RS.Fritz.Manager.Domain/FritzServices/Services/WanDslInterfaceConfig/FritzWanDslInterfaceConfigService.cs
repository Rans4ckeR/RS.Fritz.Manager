namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzWanDslInterfaceConfigService : FritzServiceClient<IFritzWanDslInterfaceConfigService>, IFritzWanDslInterfaceConfigService
    {
        public const string ControlUrl = "/upnp/control/wandslifconfig1";

        public FritzWanDslInterfaceConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        public Task<WanDslInterfaceConfigGetDSLDiagnoseInfoResponse> GetDSLDiagnoseInfoAsync(WanDslInterfaceConfigGetDSLDiagnoseInfoRequest wanDslInterfaceConfigGetDSLDiagnoseInfoRequest)
        {
            // RoSchmi
            var returnResult = Channel.GetDSLDiagnoseInfoAsync(wanDslInterfaceConfigGetDSLDiagnoseInfoRequest);
            return returnResult;
           // return Channel.GetDSLDiagnoseInfoAsync(wanDslInterfaceConfigGetDSLDiagnoseInfoRequest);
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
    }
}