namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoDisconnectTimeSpan")]
public readonly record struct WanPppConnectionGetAutoDisconnectTimeSpanRequest;