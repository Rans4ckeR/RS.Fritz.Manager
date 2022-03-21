namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDestinationAddress")]
public readonly record struct WanDslLinkConfigGetDestinationAddressRequest;