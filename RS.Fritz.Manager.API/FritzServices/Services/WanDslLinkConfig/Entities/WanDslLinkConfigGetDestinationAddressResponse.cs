namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDestinationAddressResponse")]
public readonly record struct WanDslLinkConfigGetDestinationAddressResponse(
    [property: MessageBodyMember(Name = "NewDestinationAddress")] string DestinationAddress);