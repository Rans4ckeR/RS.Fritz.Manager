namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetAutoDisconnectTimeSpan")]
public sealed record WanPppConnectionGetAutoDisconnectTimeSpanRequest;