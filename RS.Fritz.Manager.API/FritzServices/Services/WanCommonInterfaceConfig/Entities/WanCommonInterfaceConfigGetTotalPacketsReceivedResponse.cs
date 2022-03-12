namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsReceivedResponse")]
public sealed record WanCommonInterfaceConfigGetTotalPacketsReceivedResponse
{
    [MessageBodyMember(Name = "NewTotalPacketsReceived")]
    public uint TotalPacketsReceived { get; set; }
}