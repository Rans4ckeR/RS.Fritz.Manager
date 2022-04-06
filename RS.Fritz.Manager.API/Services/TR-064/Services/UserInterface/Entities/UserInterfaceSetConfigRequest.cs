namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "SetConfig")]
public readonly record struct UserInterfaceSetConfigRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_AutoUpdateMode")] string AutoUpdateMode);