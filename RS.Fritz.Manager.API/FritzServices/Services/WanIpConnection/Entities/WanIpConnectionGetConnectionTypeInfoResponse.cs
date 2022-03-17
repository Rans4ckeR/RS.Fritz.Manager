namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetConnectionTypeInfoResponse")]
public sealed record WanIpConnectionGetConnectionTypeInfoResponse
{
    [MessageBodyMember(Name = "NewConnectionType")]
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public string ConnectionType { get; set; }

    [MessageBodyMember(Name = "NewPossibleConnectionTypes")]
    public string PossibleConnectionTypes { get; set; }
}