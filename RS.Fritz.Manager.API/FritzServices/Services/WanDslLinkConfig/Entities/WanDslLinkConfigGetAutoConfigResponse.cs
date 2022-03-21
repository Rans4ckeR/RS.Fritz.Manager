namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoConfigResponse")]
public readonly record struct WanDslLinkConfigGetAutoConfigResponse(
    [property: MessageBodyMember(Name = "NewAutoConfig")] bool AutoConfig);