namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetExternalIpAddressResponse")]
public readonly record struct WanConnectionGetExternalIpAddressResponse(
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIpAddress);