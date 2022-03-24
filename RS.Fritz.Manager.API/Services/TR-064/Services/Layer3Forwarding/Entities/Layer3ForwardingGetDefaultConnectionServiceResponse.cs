namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetDefaultConnectionServiceResponse")]
public readonly record struct Layer3ForwardingGetDefaultConnectionServiceResponse(
    [property: MessageBodyMember(Name = "NewDefaultConnectionService")] string DefaultConnectionService);