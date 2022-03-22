namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAutoConfigResponse")]
public readonly record struct WanDslLinkConfigGetAutoConfigResponse(
    [property: MessageBodyMember(Name = "NewAutoConfig")] bool AutoConfig);