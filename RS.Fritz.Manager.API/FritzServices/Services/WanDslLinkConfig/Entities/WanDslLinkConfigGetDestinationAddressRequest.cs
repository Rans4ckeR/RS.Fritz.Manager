namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDestinationAddress")]
public readonly record struct WanDslLinkConfigGetDestinationAddressRequest;