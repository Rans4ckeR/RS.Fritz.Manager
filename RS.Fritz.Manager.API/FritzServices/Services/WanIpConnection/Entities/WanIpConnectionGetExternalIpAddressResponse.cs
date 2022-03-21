namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetExternalIpAddressResponse")]
public readonly record struct WanIpConnectionGetExternalIpAddressResponse(
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIpAddress);