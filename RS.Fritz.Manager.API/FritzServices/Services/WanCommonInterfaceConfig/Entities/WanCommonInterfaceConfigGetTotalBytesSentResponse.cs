namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalBytesSentResponse")]
public sealed record WanCommonInterfaceConfigGetTotalBytesSentResponse
{
    [MessageBodyMember(Name = "NewTotalBytesSent")]
    public uint TotalBytesSent { get; set; }
}