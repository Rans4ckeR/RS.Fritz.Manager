namespace RS.Fritz.Manager.API;

[MessageContract(WrapperName = "GetOnlineMonitorResponse")]
public readonly record struct WanCommonInterfaceConfigGetOnlineMonitorResponse(
    [property: MessageBodyMember(Name = "NewTotalNumberSyncGroups")] uint TotalNumberSyncGroups,
    [property: MessageBodyMember(Name = "NewSyncGroupName")] string SyncGroupName,
    [property: MessageBodyMember(Name = "NewSyncGroupMode")] string SyncGroupMode,
    [property: MessageBodyMember(Name = "Newmax_ds")] uint MaxDownstream,
    [property: MessageBodyMember(Name = "Newmax_us")] uint MaxUpstream,
    [property: MessageBodyMember(Name = "Newds_current_bps")] string DownstreamInternetBps,
    [property: MessageBodyMember(Name = "Newmc_current_bps")] string DownstreamIpTvBps,
    [property: MessageBodyMember(Name = "Newus_current_bps")] string UpstreamTotalBps,
    [property: MessageBodyMember(Name = "Newprio_realtime_bps")] string UpstreamRealTimeApplicationsBps,
    [property: MessageBodyMember(Name = "Newprio_high_bps")] string UpstreamPrioritizedApplicationsBps,
    [property: MessageBodyMember(Name = "Newprio_default_bps")] string UpstreamNormalApplicationsBps,
    [property: MessageBodyMember(Name = "Newprio_low_bps")] string UpstreamBackgroundApplicationsBps);