namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "SetWanAccessTypeResponse")]
public readonly record struct WanCommonInterfaceConfigSetWanAccessTypeResponse;