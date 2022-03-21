namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalBytesSentResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesSentResponse(
    [property: MessageBodyMember(Name = "NewTotalBytesSent")] uint TotalBytesSent);