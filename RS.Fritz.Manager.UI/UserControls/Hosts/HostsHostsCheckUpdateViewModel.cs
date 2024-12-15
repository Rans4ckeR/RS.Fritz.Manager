namespace RS.Fritz.Manager.UI;

internal sealed class HostsHostsCheckUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger logger)
    : ManualOperationViewModel<HostsHostsCheckUpdateRequest, HostsHostsCheckUpdateResponse>(deviceLoginInfo, logger, "HostsHostsCheckUpdate", "Check Hosts Update", (d, _) => d.HostsHostsCheckUpdateAsync());