namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetConfigFile")]
public readonly record struct DeviceConfigGetConfigFileRequest(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_Password")] string Password);