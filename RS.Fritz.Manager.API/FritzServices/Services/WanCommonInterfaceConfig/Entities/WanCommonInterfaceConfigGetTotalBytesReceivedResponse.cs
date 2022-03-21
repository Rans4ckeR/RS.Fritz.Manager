namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalBytesReceivedResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalBytesReceivedResponse(
    [property: MessageBodyMember(Name = "NewTotalBytesReceived")] uint TotalBytesReceived);