namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDestinationAddressResponse")]
public readonly record struct WanDslLinkConfigGetDestinationAddressResponse(
    [property: MessageBodyMember(Name = "NewDestinationAddress")] string DestinationAddress);