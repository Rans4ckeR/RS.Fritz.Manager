namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "AvmGetInfo")]
public readonly record struct UserInterfaceAvmGetInfoRequest;