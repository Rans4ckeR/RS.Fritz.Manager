namespace RS.Fritz.Manager.API
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzWanIpConnectionService : FritzServiceClient<IFritzWanIpConnectionService>, IFritzWanIpConnectionService
    {
        public const string ControlUrl = "/upnp/control/wanipconnection1";

        public FritzWanIpConnectionService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        public Task<WanIpConnectionGetInfoResponse> GetInfoAsync(WanIpConnectionGetInfoRequest wanIpConnectionGetInfoRequest)
        {
            return Channel.GetInfoAsync(wanIpConnectionGetInfoRequest);
        }
    }
}