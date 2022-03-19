namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDestinationAddressResponse")]
public sealed record WanDslLinkConfigGetDestinationAddressResponse
{
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewDestinationAddress")]
    public string DestinationAddress { get; set; }
}