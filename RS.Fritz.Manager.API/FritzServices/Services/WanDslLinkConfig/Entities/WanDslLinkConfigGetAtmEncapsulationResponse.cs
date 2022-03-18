namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAtmEncapsulationResponse")]
public sealed record WanDslLinkConfigGetAtmEncapsulationResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewATMEncapsulation")]
    public string AtmEncapsulation { get; set; }
}