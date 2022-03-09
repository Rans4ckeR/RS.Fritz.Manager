namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetCommonLinkProperties")]

public sealed record WanCommonInterfaceConfigGetCommonLinkPropertiesRequest;