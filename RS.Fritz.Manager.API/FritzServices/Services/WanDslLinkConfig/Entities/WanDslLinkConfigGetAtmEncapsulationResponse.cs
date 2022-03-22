namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAtmEncapsulationResponse")]
public readonly record struct WanDslLinkConfigGetAtmEncapsulationResponse(
    [property: MessageBodyMember(Name = "NewATMEncapsulation")] string AtmEncapsulation);