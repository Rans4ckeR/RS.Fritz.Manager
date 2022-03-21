namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetExternalIpAddressResponse")]
public readonly record struct WanConnectionGetExternalIpAddressResponse(
    [property: MessageBodyMember(Name = "NewExternalIPAddress")] string ExternalIpAddress);