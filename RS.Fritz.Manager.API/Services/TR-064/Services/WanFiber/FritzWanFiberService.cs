using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzWanFiberService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzWanFiberService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzWanFiberService
{
    public Task<WanFiberGetInfoResponse> GetInfoAsync(WanFiberGetInfoRequest wanFiberGetInfoRequest)
        => Channel.GetInfoAsync(wanFiberGetInfoRequest);

    Task<WanFiberGetInfoGponResponse> IFritzWanFiberService.GetInfoGponAsync(WanFiberGetInfoGponRequest wanFiberGetInfoGponRequest)
        => Channel.GetInfoGponAsync(wanFiberGetInfoGponRequest);

    Task<WanFiberGetStatisticsResponse> IFritzWanFiberService.GetStatisticsAsync(WanFiberGetStatisticsRequest wanFiberGetStatisticsRequest)
        => Channel.GetStatisticsAsync(wanFiberGetStatisticsRequest);
}