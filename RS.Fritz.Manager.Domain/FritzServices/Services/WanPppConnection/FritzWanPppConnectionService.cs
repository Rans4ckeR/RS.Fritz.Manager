namespace RS.Fritz.Manager.Domain
{
    using System.Net;
    using System.ServiceModel;
    using System.Threading.Tasks;

    public sealed class FritzWanPppConnectionService : FritzServiceClient<IFritzWanPppConnectionService>, IFritzWanPppConnectionService
    {
        public const string ControlUrl = "/upnp/control/wanpppconn1";

        public FritzWanPppConnectionService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
            : base(endpointConfiguration, remoteAddress, networkCredential)
        {
        }

        public Task<WanPppConnectionGetInfoResponse> GetInfoAsync(WanPppConnectionGetInfoRequest wanPppConnectionGetInfoRequest)
        {
            return Channel.GetInfoAsync(wanPppConnectionGetInfoRequest);
        }
    }
}