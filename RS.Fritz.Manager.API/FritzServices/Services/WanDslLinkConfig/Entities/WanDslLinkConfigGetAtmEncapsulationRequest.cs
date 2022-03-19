namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAtmEncapsulation")]
public sealed record WanDslLinkConfigGetAtmEncapsulationRequest;