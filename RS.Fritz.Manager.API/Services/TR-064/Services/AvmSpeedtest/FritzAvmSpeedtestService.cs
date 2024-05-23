namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzAvmSpeedtestService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzAvmSpeedtestService>(binding, remoteAddress), IFritzAvmSpeedtestService
{
    public Task<AvmSpeedtestGetInfoResponse> GetInfoAsync(AvmSpeedtestGetInfoRequest avmSpeedtestGetInfoRequest)
        => Channel.GetInfoAsync(avmSpeedtestGetInfoRequest);

    public Task<AvmSpeedtestGetStatisticsResponse> GetStatisticsAsync(AvmSpeedtestGetStatisticsRequest avmSpeedtestGetStatisticsRequest)
        => Channel.GetStatisticsAsync(avmSpeedtestGetStatisticsRequest);
}