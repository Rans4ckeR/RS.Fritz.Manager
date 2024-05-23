namespace RS.Fritz.Manager.API;

using System.ServiceModel.Channels;

internal sealed class FritzTimeService(Binding binding, EndpointAddress remoteAddress)
    : ClientBase<IFritzTimeService>(binding, remoteAddress), IFritzTimeService
{
    public Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest)
        => Channel.GetInfoAsync(timeGetInfoRequest);

    public Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest)
        => Channel.SetNtpServersAsync(timeSetNtpServersRequest);
}