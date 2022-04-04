namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetHostListPathResponse")]
public readonly record struct HostsGetHostListPathResponse(
    [property: MessageBodyMember(Name = "NewX_AVM-DE_HostListPath")] string HostListPath);