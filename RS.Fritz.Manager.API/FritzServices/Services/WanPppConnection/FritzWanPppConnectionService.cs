namespace RS.Fritz.Manager.API;

using System.Net;
using System.ServiceModel;
using System.Threading.Tasks;

internal sealed class FritzWanPppConnectionService : FritzServiceClient<IFritzWanPppConnectionService>, IFritzWanPppConnectionService
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

    public Task<WanPppConnectionGetConnectionTypeInfoResponse> GetConnectionTypeInfoAsync(WanPppConnectionGetConnectionTypeInfoRequest wanPppConnectionGetConnectionTypeInfoRequest)
    {
        return Channel.GetConnectionTypeInfoAsync(wanPppConnectionGetConnectionTypeInfoRequest);
    }
}