namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAtmEncapsulationResponse")]
public readonly record struct WanDslLinkConfigGetAtmEncapsulationResponse(
    [property: MessageBodyMember(Name = "NewATMEncapsulation")] string AtmEncapsulation);