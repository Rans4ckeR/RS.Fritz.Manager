namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzAvmSpeedtestService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
    : FritzServiceClient<IFritzAvmSpeedtestService>(endpointConfiguration, remoteAddress, networkCredential), IFritzAvmSpeedtestService
{
    public const string ControlUrl = "/upnp/control/x_speedtest";

    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest)
        => Channel.GetInfoAsync(avmSpeedtestGetInfoRequest);

    public Task<AvmSpeedtestGetStatisticsResponse> GetStatisticsAsync(AvmSpeedtestGetStatisticsRequest avmSpeedtestGetStatisticsRequest)
        => Channel.GetStatisticsAsync(avmSpeedtestGetStatisticsRequest);
}