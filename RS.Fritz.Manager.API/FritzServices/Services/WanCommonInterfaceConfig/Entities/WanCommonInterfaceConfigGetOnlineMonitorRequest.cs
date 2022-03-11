﻿namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetOnlineMonitor")]
public sealed record WanCommonInterfaceConfigGetOnlineMonitorRequest
{
    [MessageBodyMember(Name = "NewSyncGroupIndex")]
    public ushort SyncGroupIndex { get; set; }
}