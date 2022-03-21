namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetWanAccessType")]
public readonly record struct WanCommonInterfaceConfigSetWanAccessTypeRequest(
    [property: MessageBodyMember(Name = "NewAccessType")] string AccessType);