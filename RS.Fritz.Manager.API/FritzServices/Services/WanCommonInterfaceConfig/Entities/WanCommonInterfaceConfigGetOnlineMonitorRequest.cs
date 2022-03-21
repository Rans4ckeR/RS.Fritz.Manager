namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetOnlineMonitor")]
public readonly record struct WanCommonInterfaceConfigGetOnlineMonitorRequest(
    [property: MessageBodyMember(Name = "NewSyncGroupIndex")] uint SyncGroupIndex);