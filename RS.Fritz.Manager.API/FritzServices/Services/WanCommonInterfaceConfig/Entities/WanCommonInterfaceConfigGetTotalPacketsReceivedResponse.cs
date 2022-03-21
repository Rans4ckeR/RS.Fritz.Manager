namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetTotalPacketsReceivedResponse")]
public readonly record struct WanCommonInterfaceConfigGetTotalPacketsReceivedResponse(
    [property: MessageBodyMember(Name = "NewTotalPacketsReceived")] uint TotalPacketsReceived);