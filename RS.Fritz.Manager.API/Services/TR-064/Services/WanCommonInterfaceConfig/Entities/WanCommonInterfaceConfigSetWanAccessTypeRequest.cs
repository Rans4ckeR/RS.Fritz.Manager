namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetWanAccessType")]
public readonly record struct WanCommonInterfaceConfigSetWanAccessTypeRequest(
    [property: MessageBodyMember(Name = "NewAccessType")] string AccessType);