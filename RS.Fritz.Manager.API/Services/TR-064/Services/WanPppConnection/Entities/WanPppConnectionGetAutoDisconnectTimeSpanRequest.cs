namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetAutoDisconnectTimeSpan")]
public readonly record struct WanPppConnectionGetAutoDisconnectTimeSpanRequest;