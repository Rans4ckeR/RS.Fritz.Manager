namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetDefaultConnectionServiceResponse")]
public readonly record struct Layer3ForwardingGetDefaultConnectionServiceResponse(
    [property: MessageBodyMember(Name = "NewDefaultConnectionService")] string DefaultConnectionService);