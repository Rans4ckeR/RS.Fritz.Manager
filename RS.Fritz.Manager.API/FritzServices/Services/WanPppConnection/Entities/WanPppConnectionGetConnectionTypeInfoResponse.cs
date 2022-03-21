namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetConnectionTypeInfoResponse")]
public readonly record struct WanPppConnectionGetConnectionTypeInfoResponse(
    [property: MessageBodyMember(Name = "NewConnectionType")] string ConnectionType,
    [property: MessageBodyMember(Name = "NewPossibleConnectionTypes")] string PossibleConnectionTypes);