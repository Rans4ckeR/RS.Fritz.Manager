namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsSentResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsSentResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsSent")] uint TotalPacketsSent);