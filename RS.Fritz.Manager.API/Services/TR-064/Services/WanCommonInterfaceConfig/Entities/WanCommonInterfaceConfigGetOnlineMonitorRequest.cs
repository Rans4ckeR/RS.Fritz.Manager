namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetOnlineMonitor")]
public readonly record struct WanCommonInterfaceConfigGetOnlineMonitorRequest(
    [property: MessageBodyMember(Name = "NewSyncGroupIndex")] uint SyncGroupIndex);