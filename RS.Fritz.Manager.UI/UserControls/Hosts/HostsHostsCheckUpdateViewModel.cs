namespace RS.Fritz.Manager.UI;

internal sealed class HostsHostsCheckUpdateViewModel(DeviceLoginInfo deviceLoginInfo, ILogger<HostsHostsCheckUpdateViewModel> logger)
    : ManualOperationViewModel<HostsHostsCheckUpdateRequest, HostsHostsCheckUpdateResponse>(deviceLoginInfo, logger, "HostsHostsCheckUpdate", "Check Hosts Update", static (d, _) => d.HostsHostsCheckUpdateAsync());