namespace RS.Fritz.Manager.API;

using System.ServiceModel;

[MessageContract(WrapperName = "GetOnlineMonitorResponse")]
public sealed record WanCommonInterfaceConfigGetOnlineMonitorResponse
{
    [MessageBodyMember(Name = "NewTotalNumberSyncGroups")]
    public uint TotalNumberSyncGroups { get; set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    [MessageBodyMember(Name = "NewSyncGroupName")]
    public string SyncGroupName { get; set; }

    [MessageBodyMember(Name = "NewSyncGroupMode")]
    public string SyncGroupMode { get; set; }

    [MessageBodyMember(Name = "Newmax_ds")]
    public uint MaxDownstream { get; set; }

    [MessageBodyMember(Name = "Newmax_us")]
    public uint MaxUpstream { get; set; }

    [MessageBodyMember(Name = "Newds_current_bps")]
    public string DownstreamInternetBps { get; set; }

    [MessageBodyMember(Name = "Newmc_current_bps")]
    public string DownstreamIpTvBps { get; set; }

    [MessageBodyMember(Name = "Newus_current_bps")]
    public string UpstreamTotalBps { get; set; }

    [MessageBodyMember(Name = "Newprio_realtime_bps")]
    public string UpstreamRealTimeApplicationsBps { get; set; }

    [MessageBodyMember(Name = "Newprio_high_bps")]
    public string UpstreamPrioritizedApplicationsBps { get; set; }

    [MessageBodyMember(Name = "Newprio_default_bps")]
    public string UpstreamNormalApplicationsBps { get; set; }

    [MessageBodyMember(Name = "Newprio_low_bps")]
    public string UpstreamBackgroundApplicationsBps { get; set; }
}