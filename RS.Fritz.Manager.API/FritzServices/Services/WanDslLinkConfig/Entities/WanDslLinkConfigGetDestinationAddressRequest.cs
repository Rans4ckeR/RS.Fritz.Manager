namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDestinationAddress")]
public sealed record WanDslLinkConfigGetDestinationAddressRequest;