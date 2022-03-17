namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetStatusInfoResponse")]
public sealed record WanPppConnectionGetStatusInfoResponse
{
    [MessageBodyMember(Name = "NewConnectionStatus")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string ConnectionStatus { get; set; }

    [MessageBodyMember(Name = "NewLastConnectionError")]
    public string LastConnectionError { get; set; }

    [MessageBodyMember(Name = "NewUptime")]
    public uint Uptime { get; set; }
}