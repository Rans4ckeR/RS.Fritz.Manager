namespace RS.Fritz.Manager.API;

using System.Net;

internal sealed class FritzTimeService : FritzServiceClient<IFritzTimeService>, IFritzTimeService
{
    public const string ControlUrl = "/upnp/control/time";

    public FritzTimeService(FritzServiceEndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress, NetworkCredential networkCredential)
        : base(endpointConfiguration, remoteAddress, networkCredential)
    {
    }

    public Task<TimeGetInfoResponse> GetInfoAsync(TimeGetInfoRequest timeGetInfoRequest)
        => Channel.GetInfoAsync(timeGetInfoRequest);

    public Task<TimeSetNtpServersResponse> SetNtpServersAsync(TimeSetNtpServersRequest timeSetNtpServersRequest)
        => Channel.SetNtpServersAsync(timeSetNtpServersRequest);
}