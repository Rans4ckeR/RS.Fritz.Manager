namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsSentResponse")]
public sealed record WanCommonInterfaceConfigGetTotalPacketsSentResponse
{
    [MessageBodyMember(Name = "NewTotalPacketsSent")]
    public uint TotalPacketsSent { get; set; }
}