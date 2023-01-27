namespace RS.Fritz.Manager.UI;

internal sealed class HostsHostsCheckUpdateViewModel : ManualOperationViewModel<HostsHostsCheckUpdateRequest, HostsHostsCheckUpdateResponse>
{
    public HostsHostsCheckUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
        : base(deviceLoginInfo, logger, "HostsHostsCheckUpdate", "Check Hosts Update", (d, _) => d.HostsHostsCheckUpdateAsync())
    {
    }
}