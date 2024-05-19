namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetConfigFileResponse")]
public readonly record struct DeviceConfigGetConfigFileResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_ConfigFileUrl")] string ConfigFileUrl);