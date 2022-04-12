namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetInfo")]
public readonly record struct TimeGetInfoRequest;