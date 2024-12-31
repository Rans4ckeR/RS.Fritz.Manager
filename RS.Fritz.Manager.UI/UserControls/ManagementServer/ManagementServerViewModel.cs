namespace RS.Fritz.Manager.UI;

internal sealed class ManagementServerViewModel(
    DeviceLoginInfo deviceLoginInfo,
    ILogger<ManagementServerViewModel> logger,
    ManagementServerSetManagementServerUrlViewModel managementServerSetManagementServerUrlViewModel,
    ManagementServerSetManagementServerUsernameViewModel managementServerSetManagementServerUsernameViewModel,
    ManagementServerSetManagementServerPasswordViewModel managementServerSetManagementServerPasswordViewModel,
    ManagementServerSetPeriodicInformViewModel managementServerSetPeriodicInformViewModel,
    ManagementServerSetConnectionRequestAuthenticationViewModel managementServerSetConnectionRequestAuthenticationViewModel,
    ManagementServerSetUpgradeManagementViewModel managementServerSetUpgradeManagementViewModel,
    ManagementServerSetTr069EnableViewModel managementServerSetTr069EnableViewModel,
    ManagementServerSetTr069FirmwareDownloadEnabledViewModel managementServerSetTr069FirmwareDownloadEnabledViewModel)
    : FritzServiceViewModel(deviceLoginInfo, logger, "ManagementServer")
{
    public KeyValuePair<ManagementServerGetInfoResponse?, UPnPFault?>? ManagementServerGetInfoResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public KeyValuePair<ManagementServerGetTr069FirmwareDownloadEnabledResponse?, UPnPFault?>?
        ManagementServerGetTr069FirmwareDownloadEnabledResponse
    {
        get;
        private set => _ = SetProperty(ref field, value);
    }

    public ManagementServerSetManagementServerUrlViewModel ManagementServerSetManagementServerUrlViewModel { get; } = managementServerSetManagementServerUrlViewModel;

    public ManagementServerSetManagementServerUsernameViewModel ManagementServerSetManagementServerUsernameViewModel { get; } = managementServerSetManagementServerUsernameViewModel;

    public ManagementServerSetManagementServerPasswordViewModel ManagementServerSetManagementServerPasswordViewModel { get; } = managementServerSetManagementServerPasswordViewModel;

    public ManagementServerSetPeriodicInformViewModel ManagementServerSetPeriodicInformViewModel { get; } = managementServerSetPeriodicInformViewModel;

    public ManagementServerSetConnectionRequestAuthenticationViewModel ManagementServerSetConnectionRequestAuthenticationViewModel { get; } = managementServerSetConnectionRequestAuthenticationViewModel;

    public ManagementServerSetUpgradeManagementViewModel ManagementServerSetUpgradeManagementViewModel { get; } = managementServerSetUpgradeManagementViewModel;

    public ManagementServerSetTr069EnableViewModel ManagementServerSetTr069EnableViewModel { get; } = managementServerSetTr069EnableViewModel;

    public ManagementServerSetTr069FirmwareDownloadEnabledViewModel ManagementServerSetTr069FirmwareDownloadEnabledViewModel { get; } = managementServerSetTr069FirmwareDownloadEnabledViewModel;

    protected override ValueTask DoExecuteDefaultCommandAsync(CancellationToken cancellationToken)
        => API.TaskExtensions.WhenAllSafe([GetManagementServerGetInfoAsync(), GetManagementServerGetTr069FirmwareDownloadEnabledAsync()], true);

    private async Task GetManagementServerGetInfoAsync()
        => ManagementServerGetInfoResponse = await ExecuteApiAsync(static q => q.ManagementServerGetInfoAsync()).ConfigureAwait(true);

    private async Task GetManagementServerGetTr069FirmwareDownloadEnabledAsync()
        => ManagementServerGetTr069FirmwareDownloadEnabledResponse = await ExecuteApiAsync(static q => q.ManagementServerGetTr069FirmwareDownloadEnabledAsync()).ConfigureAwait(true);
}