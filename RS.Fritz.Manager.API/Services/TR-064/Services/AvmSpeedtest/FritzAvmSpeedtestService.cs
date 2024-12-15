using System.Net;

namespace RS.Fritz.Manager.API;

internal sealed class FritzAvmSpeedtestService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzAvmSpeedtestService>(endpointConfiguration, remoteAddress, networkCredential), IFritzAvmSpeedtestService
{
    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest)
        => Channel.GetInfoAsync(avmSpeedtestGetInfoRequest);

    public Task<AvmSpeedtestGetStatisticsResponse> GetStatisticsAsync(AvmSpeedtestGetStatisticsRequest avmSpeedtestGetStatisticsRequest)
        => Channel.GetStatisticsAsync(avmSpeedtestGetStatisticsRequest);
}