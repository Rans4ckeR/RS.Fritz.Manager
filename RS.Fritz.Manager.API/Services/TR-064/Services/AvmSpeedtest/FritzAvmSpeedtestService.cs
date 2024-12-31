using System.Net;
using Microsoft.Extensions.Logging;

namespace RS.Fritz.Manager.API;

internal sealed class FritzAvmSpeedtestService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential, ILoggerFactory loggerFactory)
    : FritzServiceClient<IFritzAvmSpeedtestService>(endpointConfiguration, remoteAddress, networkCredential, loggerFactory), IFritzAvmSpeedtestService
{
    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest)
        => Channel.GetInfoAsync(avmSpeedtestGetInfoRequest);

    public Task<AvmSpeedtestGetStatisticsResponse> GetStatisticsAsync(AvmSpeedtestGetStatisticsRequest avmSpeedtestGetStatisticsRequest)
        => Channel.GetStatisticsAsync(avmSpeedtestGetStatisticsRequest);
}