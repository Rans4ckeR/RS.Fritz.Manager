namespace RS.Fritz.Manager.API;

using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

internal sealed class FritzWanDslLinkConfigService : FritzServiceClient<IFritzWanDslLinkConfigService>, IFritzWanDslLinkConfigService
{
    public const string ControlUrl = "/upnp/control/wandsllinkconfig1";

    public FritzWanDslLinkConfigService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<WanDslLinkConfigGetInfoResponse> GetInfoAsync(WanDslLinkConfigGetInfoRequest wanDslLinkConfigGetInfoRequest)
    {
        return Channel.GetInfoAsync(wanDslLinkConfigGetInfoRequest);
    }

    public Task<WanDslLinkConfigGetDslLinkInfoResponse> GetDslLinkInfoAsync(WanDslLinkConfigGetDslLinkInfoRequest wanDslLinkConfigGetDslLinkInfoRequest)
    {
        return Channel.GetDslLinkInfoAsync(wanDslLinkConfigGetDslLinkInfoRequest);
    }
}